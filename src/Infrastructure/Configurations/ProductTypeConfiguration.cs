using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.HasData(
            new ProductType
            {
                Id = new Guid("dc1cc068-6c14-4cb2-9b3d-858953d41e59"),
                Name = "Type 1"
            },
            new ProductType
            {
                Id = new Guid("E29B5399-D2D0-4889-BDBC-1A74B2F06AAF"),
                Name = "Type 2"
            },
            new ProductType
            {
                Id = new Guid("690A87FE-1E04-470A-A11B-50807F73F5BA"),
                Name = "Type 3"
            }
        );
    }
}