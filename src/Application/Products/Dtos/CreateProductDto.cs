namespace Application.Products.Dtos;

/// <summary>
/// Data transfer object for creating a product.
/// </summary>
public sealed class CreateProductDto
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public Guid ProductTypeId { get; init; }
    public Guid ProductBrandId { get; init; }
}