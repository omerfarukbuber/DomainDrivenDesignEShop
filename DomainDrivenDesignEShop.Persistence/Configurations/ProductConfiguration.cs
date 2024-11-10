using DomainDrivenDesignEShop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainDrivenDesignEShop.Persistence.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(productId => productId.Value,
                value => new ProductId(value));

        builder.Property(p => p.Name).HasMaxLength(255).IsRequired();

        builder.Property(p => p.Sku)
            .HasMaxLength(15)
            .HasConversion(sku => sku.Value,
                value => Sku.Create(value)!);
        builder.HasIndex(p => p.Sku).IsUnique();

        builder.OwnsOne(p => p.Price, priceBuilder =>
        {
            priceBuilder.Property(m => m.Currency).HasMaxLength(3);
        });

    }
}