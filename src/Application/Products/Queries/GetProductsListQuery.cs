using Application.Products.Dtos;
using Application.RequestFeatures;
using MediatR;

namespace Application.Products.Queries;

/// <summary>
/// Query to get a list of products with optional parameters for filtering and paging.
/// </summary>
public sealed class GetProductsListQuery : IRequest<PagedList<ProductToReturnDto>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetProductsListQuery"/> class.
    /// </summary>
    /// <param name="parameters">Optional parameters for filtering and paging.</param>
    public GetProductsListQuery(ProductsRequestParams? parameters)
    {
        Params = parameters;
    }

    /// <summary>
    /// Gets or initializes the optional parameters for filtering and paging.
    /// </summary>
    public ProductsRequestParams? Params { get; init; }
}