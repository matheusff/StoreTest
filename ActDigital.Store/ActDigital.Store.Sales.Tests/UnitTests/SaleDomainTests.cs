using ActDigital.Store.Core.DomainObjects;
using ActDigital.Store.Sales.Domain;
using FluentAssertions;
using Xunit;

namespace ActDigital.Store.Sales.Tests.UnitTests;

public class SaleDomainTests
{
    [Fact]
    public void SaleValidationExceptionsTest()
    {
        var saleNumberex = Assert.Throws<DomainException>(() =>
            new Sale(Guid.Empty, 0, DateTime.Now, Guid.NewGuid(), "branchTest ",  
                new List<ProductItem>(), 10, true)
        );
        
        var dateEx = Assert.Throws<DomainException>(() =>
            new Sale(Guid.Empty,10, null, Guid.NewGuid(), "branchTest ",  
                new List<ProductItem>(), 10, true)
        );
        
        var customerIdEx= Assert.Throws<DomainException>(() =>
            new Sale(Guid.Empty,10, DateTime.Now, Guid.Empty, "branchTest ",  
                new List<ProductItem>(), 10, true)
        );
        
        var branchSaleMadeEx = Assert.Throws<DomainException>(() =>
            new Sale(Guid.Empty,10, DateTime.Now, Guid.NewGuid(), null,  
                new List<ProductItem>(), 10, true)
        );
        
        var itemsEx = Assert.Throws<DomainException>(() =>
            new Sale(Guid.Empty,10, DateTime.Now, Guid.NewGuid(), "branchTest ",  
                null, 10, true)
        );
        
        var totalSaleAmountEx = Assert.Throws<DomainException>(() =>
            new Sale(Guid.Empty,10, DateTime.Now, Guid.NewGuid(), "branchTest ",  
                new List<ProductItem>(), 0, true)
        );
        saleNumberex.Message.Should().Be("The Sale Number field must be greater than 0");
        dateEx.Message.Should().Be("The Date field cannot be null");
        customerIdEx.Message.Should().Be("The Customer cannot be null");
        branchSaleMadeEx.Message.Should().Be("The Branch Sale Made filed cannot be null");
        itemsEx.Message.Should().Be("The Products must have at least one item");
        totalSaleAmountEx.Message.Should().Be("The Total Sale Amount field must be greater than 0");
    }

    [Fact]
    public void SaleCheckDiscountItemsTest()
    {
        var sale = new Sale(Guid.Empty,10, DateTime.Now, Guid.NewGuid(), "branchTest ",
            new List<ProductItem>()
            {
                new(Guid.NewGuid(), 6, 10, true),
                new(Guid.NewGuid(), 15, 10, true),
                new(Guid.NewGuid(), 2, 30, true)
            }, 270, true);

        sale.CheckDisccountForIndenticalItems();

        sale.Discount.Should().Be(36);
        (sale.TotalSaleAmount - sale.Discount).Should().Be(234);
    }
    
    
    [Fact]
    public void SaleCheckDiscountItemsAbovo20IdencticalItemTest()
    {
        var sale =  Assert.Throws<DomainException>(() =>
            new Sale(Guid.Empty,10, DateTime.Now, Guid.NewGuid(), "branchTest ",
            new List<ProductItem>()
            {
                new(Guid.NewGuid(), 23, 10, true),
                new(Guid.NewGuid(), 15, 10, true),
                new(Guid.NewGuid(), 2, 30, true)
            }, 270, true));

        sale.Message.Should().Be("It's not possible to sell above 20 identical items");
    }
}