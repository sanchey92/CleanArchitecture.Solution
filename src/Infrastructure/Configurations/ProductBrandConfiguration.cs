using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        builder.HasData(
            new ProductBrand
            {
                Id = new Guid("794A5BF3-DB1F-4D4A-86E7-1021DBB8F667"),
                Name = "Brand 1"
            },
            new ProductBrand
            {
                Id = new Guid("5f71a742-c0ab-4a86-8754-8328ef4f37f4"),
                Name = "Brand 2"
            },
            new ProductBrand
            {
                Id = new Guid("9B8544AC-99FB-4201-ACD4-B6C25C9C1918"),
                Name = "Brand 3"
            }
        );
    }
}