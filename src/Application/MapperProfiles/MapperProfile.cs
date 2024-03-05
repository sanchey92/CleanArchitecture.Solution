using Application.Products.Dtos;
using AutoMapper;
using Domain.Entity;

namespace Application.MapperProfiles;

/// <summary>
/// AutoMapper profile for mapping entities to DTOs.
/// </summary>
public class MapperProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MapperProfile"/> class.
    /// </summary>
    public MapperProfile()
    {
        CreateMap<Product, ProductToReturnDto>()
            .ForMember(p => p.ProductBrand, o => o.MapFrom(x => x.ProductBrand!.Name))
            .ForMember(p => p.ProductType, o => o.MapFrom(x => x.ProductType!.Name));

        CreateMap<CreateProductDto, Product>();
    }
}