using ActDigital.Store.Core.DomainObjects;

namespace ActDigital.Store.Sales.Domain;

public class ProductItem : Entity
{
    public Guid SaleId { get; set; }
    public Sale Sale { get; set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public bool IsActive { get; private set; }
    
    public ProductItem(Guid productId, int quantity, decimal unitPrice, bool isActive)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        IsActive = isActive;

        Validation();
    }
    
    public ProductItem(){}

    private void Validation()
    {
        Validations.IsGuidEmpty(ProductId, "The ProductId Name cannot be null");
        Validations.IsGreaterThanZero(Quantity, "The Quantity field must be greater than 0");
        Validations.IsGreaterThanZero(UnitPrice, "The Unit Price field must be greater than 0");
    }
}