using Application.Products.Commands;
using Application.Products.Dtos;
using Application.Products.Queries;
using Application.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.ActionFilters;

namespace Presentation.Controllers.Controllers.v1;

/// <summary>
/// Controller for managing products.
/// </summary>
public class ProductsController : BaseController
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductsController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator for handling requests.</param>
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// Gets a list of products with optional pagination.
    /// </summary>
    /// <param name="requestParams">The parameters for filtering and pagination.</param>
    /// <returns>An ActionResult containing the list of products.</returns>
    [HttpGet(Name = "GetCompanies")]
    [AddPaginationHeaderAttribute<ProductToReturnDto>]
    public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetAllProducts(
        [FromQuery] ProductsRequestParams requestParams)
    {
        var query = new GetProductsListQuery(requestParams);
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="productDto">The data for creating the product.</param>
    /// <returns>An IActionResult indicating the result of the operation.</returns>
    [HttpPost(Name = "CreateCompany")]
    public async Task<IActionResult> CreateCompany([FromBody] CreateProductDto productDto)
    {
        await Mediator.Send(new CreateProductCommand(productDto));

        return Ok(StatusCodes.Status201Created);
    }
}