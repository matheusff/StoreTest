using ActDigital.Store.Core.Messages;

namespace ActDigital.Store.Sales.Application.Events;

public class SaleCancelledEvent : Event
{
    public Guid Id { get; set; }
    public int SaleNumber { get; set; }
    public DateTime? Date { get; set; }
    public Guid CustomerId { get; set; }
    public string BranchSaleMade { get; set; }
    public bool IsActive { get; set; }
    
    public SaleCancelledEvent(Guid id, int saleNumber, DateTime? date, Guid customerId, string branchSaleMade, bool isActive)
    {
        Id = id;
        SaleNumber = saleNumber;
        Date = date;
        CustomerId = customerId;
        BranchSaleMade = branchSaleMade;
        IsActive = isActive;
    }
}