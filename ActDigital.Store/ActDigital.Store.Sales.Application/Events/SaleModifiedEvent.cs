using ActDigital.Store.Core.Messages;
using ActDigital.Store.Sales.Application.ViewModels;

namespace ActDigital.Store.Sales.Application.Events;

public class SaleModifiedEvent : Event
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public Guid CustomerId { get; set; }
    public string BranchSaleMade { get; set; }
    public ICollection<ProductViewModel> Products { get; set; }
    public decimal TotalSaleAmount { get; set; }
    public bool IsActive { get; set; }
    
    public SaleModifiedEvent(Guid id, Guid productId, int saleNumber, DateTime date, Guid customerId, string branchSaleMade, ICollection<ProductViewModel> products, decimal totalSaleAmount, bool isActive)
    {
        Id = id;
        ProductId = productId;
        SaleNumber = saleNumber;
        Date = date;
        CustomerId = customerId;
        BranchSaleMade = branchSaleMade;
        Products = products;
        TotalSaleAmount = totalSaleAmount;
        IsActive = isActive;
    }
}