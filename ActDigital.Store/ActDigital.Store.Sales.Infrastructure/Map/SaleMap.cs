using ActDigital.Store.Sales.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ActDigital.Store.Sales.Infrastructure.Map;

public class SaleMap : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.SaleNumber).IsRequired();
        builder.Property(p => p.Date).IsRequired();
        builder.Property(p => p.CustomerId).IsRequired();
        builder.Property(p => p.BranchSaleMade).IsRequired();
        builder.Property(p => p.TotalSaleAmount).IsRequired();
        builder.Property(p => p.Discount).IsRequired();
        builder.Property(p => p.IsActive).IsRequired();
        
        builder.HasMany(p => p.Items)
            .WithOne(p => p.Sale)
            .HasForeignKey(p => p.SaleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}