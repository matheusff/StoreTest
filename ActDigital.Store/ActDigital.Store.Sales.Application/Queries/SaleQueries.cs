using ActDigital.Store.Sales.Application.ViewModels;
using ActDigital.Store.Sales.Domain.Repositories;

namespace ActDigital.Store.Sales.Application.Queries;

public class SaleQueries : ISaleQueries
{
    private readonly ISaleRepository _saleRepository;

    public SaleQueries(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<SaleViewModel?> GetSaleById(Guid saleId)
    {
        var sale = await _saleRepository.GetById(saleId);
        var saleViewModel = new SaleViewModel();

        if (sale != null)
        {
            saleViewModel.Id = sale.Id;
            saleViewModel.SaleNumber = sale.SaleNumber;
            saleViewModel.BranchSaleMade = sale.BranchSaleMade;
            saleViewModel.TotalSaleAmount = sale.TotalSaleAmount;
            saleViewModel.CustomerId = sale.CustomerId;
            saleViewModel.Date = sale.Date;
            saleViewModel.Discount = sale.Discount;
            saleViewModel.Products = sale.Items.Select(s =>
                new ProductViewModel(s.ProductId, s.Quantity, s.UnitPrice, s.IsActive)).ToList();
            saleViewModel.IsActive = sale.IsActive;
        }
       
       return saleViewModel;
    }
}