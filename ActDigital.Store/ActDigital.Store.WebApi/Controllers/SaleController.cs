using ActDigital.Store.Core.Communication.Mediator;
using ActDigital.Store.Core.Messages.Notifications;
using ActDigital.Store.Sales.Application.Commands;
using ActDigital.Store.Sales.Application.Queries;
using ActDigital.Store.Sales.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ActDigital.Store.WebApi.Controllers;

[ApiController]
[ApiVersion("1.0")]
public class SaleController : ControllerBase
{
    private readonly ISaleQueries _saleQueries;
    
    public SaleController(INotificationHandler<DomainNotification> notifications, 
                          IMediatorHandler mediatorHandler,
                          ISaleQueries saleQueries) : base(notifications, mediatorHandler)
    {
        _saleQueries = saleQueries;
    }

    [HttpPost("addSale")]
    [ProducesResponseType(typeof(SaleViewModel), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(SaleViewModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddSale(SaleViewModel saleViewModel)
    {
        var command = new AddSaleCommand(Guid.NewGuid(), saleViewModel.SaleNumber, saleViewModel.Date,
            saleViewModel.CustomerId, saleViewModel.BranchSaleMade, saleViewModel.Products,
            saleViewModel.TotalSaleAmount, saleViewModel.IsActive);
        
        await _mediatorHandler.SendCommand(command);
        
        if(!ValidOperation)
            return BadRequest(GetErrorMessages);
        
        return Ok(await _saleQueries.GetSaleById(command.Id));
    }
    
    [HttpPut("updateSale")]
    [ProducesResponseType(typeof(SaleUpdateViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(SaleUpdateViewModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSale(SaleUpdateViewModel saleUpdateViewModel)
    {
        var command = new UpdateSaleCommand(saleUpdateViewModel.Id, saleUpdateViewModel.SaleNumber, saleUpdateViewModel.Date,
            saleUpdateViewModel.CustomerId, saleUpdateViewModel.BranchSaleMade, saleUpdateViewModel.Products,
            saleUpdateViewModel.TotalSaleAmount, saleUpdateViewModel.IsActive);
        
        await _mediatorHandler.SendCommand(command);
        
        if(!ValidOperation)
            return BadRequest(GetErrorMessages);
        
        return Ok(await _saleQueries.GetSaleById(saleUpdateViewModel.Id));
    }
    
    [HttpGet("/{saleId}")]
    [ProducesResponseType(typeof(SaleViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(SaleViewModel), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSale(Guid saleId)
    {
        var result = await _saleQueries.GetSaleById(saleId);
        
        return Ok(result);
    }
    
    [HttpDelete("removeSale/{saleId}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveSale(Guid saleId)
    {
        var command = new RemoveSaleCommand(saleId);
        
        await _mediatorHandler.SendCommand(command);
        
        if(!ValidOperation)
            return BadRequest(GetErrorMessages);
        
        return Ok("Successfully remove sale");
    }
}