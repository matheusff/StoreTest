using ActDigital.Store.Core.Messages;

namespace ActDigital.Store.Sales.Application.Events;

public class ItemCancelledEvent : Event
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int SaleNumber { get; set; }
    public int Quantity { get; set; }
    public bool IsActive { get; set; }
    
    public ItemCancelledEvent(Guid id, Guid productId, int saleNumber, int quantity, bool isActive)
    {
        Id = id;
        ProductId = productId;
        SaleNumber = saleNumber;
        Quantity = quantity;
        IsActive = isActive;
    }
}