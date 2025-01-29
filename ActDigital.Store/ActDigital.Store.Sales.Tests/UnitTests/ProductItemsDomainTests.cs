using ActDigital.Store.Core.DomainObjects;
using ActDigital.Store.Sales.Domain;
using FluentAssertions;
using Xunit;

namespace ActDigital.Store.Sales.Tests.UnitTests;

public class ProductItemsDomainTests
{
    [Fact]
    public void SaleValidationExceptionsTest()
    {
        var productIdEx = Assert.Throws<DomainException>(() =>
            new ProductItem(Guid.Empty,  10, 5,true)
        );
        
        var quantityEx = Assert.Throws<DomainException>(() =>
            new ProductItem(Guid.NewGuid(),  0, 5,true)
        );
        
        var unitPriceEx = Assert.Throws<DomainException>(() =>
            new ProductItem(Guid.NewGuid(),  10, 0,true)
        );

        productIdEx.Message.Should().Be("The ProductId Name cannot be null");
        quantityEx.Message.Should().Be("The Quantity field must be greater than 0");
        unitPriceEx.Message.Should().Be("The Unit Price field must be greater than 0");
    }
}