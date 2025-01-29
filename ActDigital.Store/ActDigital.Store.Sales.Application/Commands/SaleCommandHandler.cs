using System.Net;
using ActDigital.Store.Core.Communication.Mediator;
using ActDigital.Store.Core.Messages;
using ActDigital.Store.Core.Messages.Notifications;
using ActDigital.Store.Sales.Application.Events;
using ActDigital.Store.Sales.Domain;
using ActDigital.Store.Sales.Domain.Repositories;
using MediatR;

namespace ActDigital.Store.Sales.Application.Commands;

public class SaleCommandHandler : IRequestHandler<AddSaleCommand, bool>,
                                  IRequestHandler<UpdateSaleCommand, bool>,
                                  IRequestHandler<RemoveSaleCommand, bool>
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly ISaleRepository _saleRepository;

    public SaleCommandHandler(IMediatorHandler mediatorHandler, ISaleRepository saleRepository)
    {
        _mediatorHandler = mediatorHandler;
        _saleRepository = saleRepository;
    }

    public async Task<bool> Handle(AddSaleCommand command, CancellationToken cancellationToken)
    {
        if (!ValidateCommmand(command)) return false;

        var productsList = new List<ProductItem>();
        
       command.Products.ToList().ForEach(p => productsList.Add(new(p.ProductId, p.Quantity, p.UnitPrice, p.IsActive)));

        var sale = Sale.SaleFactory.Create(Guid.Empty, command.SaleNumber, command.Date, command.CustomerId, command.BranchSaleMade,
            productsList, command.TotalSaleAmount, command.IsActive);
        
        sale.Id = command.Id;
        
        sale.AddEvent(new SaleCreatedEvent(sale.Id, command.ProductId, command.SaleNumber, command.Date, 
            command.CustomerId, command.BranchSaleMade,command.Products,  sale.TotalSaleAmount, sale.IsActive));
        
        _saleRepository.Save(sale);
        
        return await _saleRepository.UnitOfWork.Commit();
    }
    
    public async Task<bool> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        if (!ValidateCommmand(command)) return false;
        
        var saleDb = await _saleRepository.GetById(command.Id);

        if (saleDb == null)
        {
            ErrorNotification(HttpStatusCode.NotFound.ToString(), "Sale not found");
            return false;
        }
        
        var productsList = new List<ProductItem>();
        command.Products.ToList().ForEach(p => productsList.Add(new(p.ProductId, p.Quantity, p.UnitPrice, p.IsActive)));
        
        var sale = Sale.SaleFactory.Create(command.Id, command.SaleNumber, command.Date, command.CustomerId, command.BranchSaleMade,
            productsList, command.TotalSaleAmount, command.IsActive);
        
        sale.AddEvent(new SaleModifiedEvent(sale.Id, command.ProductId, command.SaleNumber, command.Date, 
            command.CustomerId, command.BranchSaleMade,command.Products,  sale.TotalSaleAmount, sale.IsActive));
        
        if(!sale.IsActive)
            sale.AddEvent(new SaleCancelledEvent(sale.Id, command.SaleNumber, command.Date, 
                command.CustomerId, command.BranchSaleMade, sale.IsActive));

        if (!sale.Items.ToList().Exists(e => !e.IsActive))
        {
            sale.Items.Where(a => !a.IsActive).ToList()
                .ForEach(item =>
                {
                    sale.AddEvent(new ItemCancelledEvent(sale.Id, item.ProductId, command.SaleNumber,  
                        item.Quantity, sale.IsActive));
                });
        }
        
        _saleRepository.Update(sale);
        
        return await _saleRepository.UnitOfWork.Commit();
    }
    
    public async Task<bool> Handle(RemoveSaleCommand command, CancellationToken cancellationToken)
    {
        if (!ValidateCommmand(command)) return false;
        
        var sale = await _saleRepository.GetById(command.Id);
        
        if (sale == null)
        {
            ErrorNotification(HttpStatusCode.NotFound.ToString(), "Sale not found");
            return false;
        }
        
        sale.AddEvent(new SaleCancelledEvent(sale.Id, sale.SaleNumber, sale.Date, 
            sale.CustomerId, sale.BranchSaleMade, sale.IsActive));
        
        _saleRepository.Remove(sale);
        
        return await _saleRepository.UnitOfWork.Commit();
    }

    private bool ValidateCommmand(Command command)
    {
        if(command.IsValid()) return true;
        
        foreach (var error in command.ValidationResult.Errors)
        {
            _mediatorHandler.PublishNotification(new DomainNotification(command.MessageType, error.ErrorMessage));
        }
        
        return false;
    }
    
    private void ErrorNotification(string codigo, string mensagem)
    {
        _mediatorHandler.PublishNotification(new DomainNotification(codigo, mensagem));
    }
}