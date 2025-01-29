using ActDigital.Store.Core.DomainObjects;
using ActDigital.Store.Core.Messages;

namespace ActDigital.Store.Sales.Domain;

public class Sale : Entity, IAggregateRoot
{
    public int SaleNumber { get; private set; }
    public DateTime? Date { get; private set; }
    public Guid CustomerId { get; private set; }
    public string BranchSaleMade { get; private set; }
    public decimal TotalSaleAmount { get; private set; }
    public decimal Discount { get; set; }
    public bool IsActive { get; private set; }
    public ICollection<ProductItem> Items { get; set; }
    
    public Sale(Guid id, int saleNumber, DateTime? date, Guid customerId, string branchSaleMade, ICollection<ProductItem> products, decimal totalSaleAmount, bool isActive)
    {
        Id = id != Guid.Empty ? id : Id;
        SaleNumber = saleNumber;
        Date = date;
        CustomerId = customerId;
        BranchSaleMade = branchSaleMade;
        Items = products;
        TotalSaleAmount = totalSaleAmount;
        IsActive = isActive;

        Validation();
        CheckDisccountForIndenticalItems();
    }
    
    public Sale(){}

    public void CheckDisccountForIndenticalItems()
    {
        Discount = 0;
        Items
            .GroupBy(group => group.Id).ToList()
            .ForEach(item =>
            {
                var totalItems = item.Sum(sum => sum.Quantity);
               
                if(totalItems is > 4 and < 10)
                    Discount += ((item.First().UnitPrice * totalItems) * 10) / 100;
                else if(totalItems is >= 10 and <= 20)
                    Discount += ((item.First().UnitPrice  * totalItems) * 20) / 100;
                else if(totalItems is > 20)
                    throw new DomainException("It's not possible to sell above 20 identical items");
            });
    }
    
    private void Validation()
    {
        Validations.IsGreaterThanZero(SaleNumber, "The Sale Number field must be greater than 0");
        Validations.IsNull(Date, "The Date field cannot be null");
        Validations.IsGuidEmpty(CustomerId, "The Customer cannot be null");
        Validations.IsNull(BranchSaleMade, "The Branch Sale Made filed cannot be null");
        Validations.IsNull(Items, "The Products must have at least one item");
        Validations.IsGreaterThanZero(TotalSaleAmount, "The Total Sale Amount field must be greater than 0");
    }

    public static class SaleFactory
    {
        public static Sale Create(Guid id, int saleNumber, DateTime? date, Guid customerId, string branchSaleMade, 
            List<ProductItem> products, decimal totalSaleAmount, bool isActive)
        {
            return new Sale(id, saleNumber, date, customerId, branchSaleMade, products, totalSaleAmount, isActive);
        }
    }
}