using ActDigital.Store.Sales.Application.ViewModels;

namespace ActDigital.Store.Sales.Application.Queries;

public interface ISaleQueries
{
    Task<SaleViewModel> GetSaleById(Guid saleId);
}