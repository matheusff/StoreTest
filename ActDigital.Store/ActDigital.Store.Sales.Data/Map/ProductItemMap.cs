﻿using ActDigital.Store.Sales.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary1ActDigital.Store.Sales.Data.Map;

public class ProductItemMap : IEntityTypeConfiguration<ProductItem>
{
    public void Configure(EntityTypeBuilder<ProductItem> builder)
    {
        builder.ToTable("ProductItem");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Quantity).IsRequired();
        builder.Property(p => p.ProductId).IsRequired();
        builder.Property(p => p.IsActive).IsRequired();
        builder.Property(p => p.UnitPrice).IsRequired();
    }
}