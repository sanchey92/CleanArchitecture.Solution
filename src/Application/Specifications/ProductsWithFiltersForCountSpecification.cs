using Application.RequestFeatures;
using Domain.Entity;

namespace Application.Specifications;

/// <summary>
/// Specification for counting products considering query parameters without loading the entities.
/// </summary>
internal sealed class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
{
    /// <summary>
    /// Initializes a new instance of <see cref="ProductsWithFiltersForCountSpecification"/>.
    /// </summary>
    /// <param name="requestParams">Request parameters for filtering products.</param>
    public ProductsWithFiltersForCountSpecification(ProductsRequestParams requestParams)
        : base(criteria: x =>
            string.IsNullOrEmpty(requestParams.Search) || x.Name!.Contains(requestParams.Search) &&
            (!requestParams.BrandId.HasValue || x.ProductBrandId == requestParams.BrandId) &&
            (!requestParams.TypeId.HasValue || x.ProductTypeId == requestParams.TypeId)
        )
    {
    }
}