using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

/// <summary>
/// Configuration for the <see cref="Product"/> entity.
/// </summary>
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    /// <summary>
    /// Configures the entity of type <see cref="Product"/>.
    /// </summary>
    /// <param name="builder">The builder used to configure the entity.</param>
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(250);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasOne(brand => brand.ProductBrand).WithMany()
            .HasForeignKey(product => product.ProductBrandId);

        builder.HasOne(type => type.ProductType).WithMany()
            .HasForeignKey(product => product.ProductTypeId);

        builder.HasData(
            new Product
            {
                Id = Guid.NewGuid(), 
                Name = "Product 1",
                Description = "Description 1", 
                Price = (decimal)10.99,
                ProductBrandId = new Guid("794A5BF3-DB1F-4D4A-86E7-1021DBB8F667"), 
                ProductTypeId = new Guid("dc1cc068-6c14-4cb2-9b3d-858953d41e59")
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Description = "Описание продукта 2",
                Price = (decimal)20.99,
                ProductBrandId = new Guid("794A5BF3-DB1F-4D4A-86E7-1021DBB8F667"), 
                ProductTypeId = new Guid("dc1cc068-6c14-4cb2-9b3d-858953d41e59")
            },
            new Product
            {
                Id = Guid.NewGuid(), 
                Name = "Product 3",
                Description = "Description 3",
                Price = (decimal)15.49,
                ProductBrandId = new Guid("5f71a742-c0ab-4a86-8754-8328ef4f37f4"),
                ProductTypeId = new Guid("dc1cc068-6c14-4cb2-9b3d-858953d41e59")
            },
            new Product
            {
                Id = Guid.NewGuid(), 
                Name = "Product 4",
                Description = "Description 4",
                Price = (decimal)30.99,
                ProductBrandId = new Guid("5f71a742-c0ab-4a86-8754-8328ef4f37f4"), 
                ProductTypeId = new Guid("E29B5399-D2D0-4889-BDBC-1A74B2F06AAF")
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 5",
                Description = "Description 5",
                Price = (decimal)25.99,
                ProductBrandId = new Guid("9B8544AC-99FB-4201-ACD4-B6C25C9C1918"),
                ProductTypeId = new Guid("dc1cc068-6c14-4cb2-9b3d-858953d41e59")
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 6", 
                Description = "Description 6",
                Price = (decimal)18.99,
                ProductBrandId = new Guid("9B8544AC-99FB-4201-ACD4-B6C25C9C1918"),
                ProductTypeId = new Guid("E29B5399-D2D0-4889-BDBC-1A74B2F06AAF")
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 7",
                Description = "Description 7",
                Price = (decimal)22.49,
                ProductBrandId = new Guid("9B8544AC-99FB-4201-ACD4-B6C25C9C1918"),
                ProductTypeId = new Guid("690A87FE-1E04-470A-A11B-50807F73F5BA")
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 8",
                Description = "Description 8",
                Price = (decimal)12.99,
                ProductBrandId = new Guid("9B8544AC-99FB-4201-ACD4-B6C25C9C1918"), 
                ProductTypeId = new Guid("690A87FE-1E04-470A-A11B-50807F73F5BA")
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 9",
                Description = "Description 9", 
                Price = (decimal)28.99,
                ProductBrandId = new Guid("5f71a742-c0ab-4a86-8754-8328ef4f37f4"),
                ProductTypeId = new Guid("690A87FE-1E04-470A-A11B-50807F73F5BA")
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Product 10", 
                Description = "Description 10",
                Price = (decimal)35.99,
                ProductBrandId = new Guid("5f71a742-c0ab-4a86-8754-8328ef4f37f4"),
                ProductTypeId = new Guid("E29B5399-D2D0-4889-BDBC-1A74B2F06AAF")
            }
        );
    }
}