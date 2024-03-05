using Application.RequestFeatures;
using Domain.Entity;

namespace Application.Specifications;

/// <summary>
/// Specification for retrieving products considering query parameters and related data about types and brands.
/// </summary>
internal sealed class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ProductsWithTypesAndBrandsSpecification"/>.
    /// </summary>
    /// <param name="requestParams">Request parameters for filtering and sorting products.</param>
    public ProductsWithTypesAndBrandsSpecification(ProductsRequestParams requestParams) :
        base(criteria: x =>
            string.IsNullOrEmpty(requestParams.Search) || x.Name!.Contains(requestParams.Search) &&
            (!requestParams.BrandId.HasValue || x.ProductBrandId == requestParams.BrandId) &&
            (!requestParams.TypeId.HasValue || x.ProductTypeId == requestParams.TypeId)
        )
    {
        AddInclude(p => p.ProductType!);
        AddInclude(p => p.ProductBrand!);
        AddOrderBy(p => p.Name!);

        var skip = (requestParams.PageIndex - 1) * requestParams.PageSize;

        ApplyPaging(skip, requestParams.PageSize);

        if (!string.IsNullOrEmpty(requestParams.Sort))
        {
            switch (requestParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(x => x.Price);
                    break;
                default:
                    AddOrderBy(x => x.Name!);
                    break;
            }
        }
    }

    /// <summary>
    /// Initializes a new instance of <see cref="ProductsWithTypesAndBrandsSpecification"/> to retrieve
    /// a product by its identifier.
    /// </summary>
    /// <param name="id">Product identifier.</param>
    public ProductsWithTypesAndBrandsSpecification(Guid id)
        : base(x => x.Id == id)
    {
        AddInclude(p => p.ProductType!);
        AddInclude(p => p.ProductBrand!);
    }
}