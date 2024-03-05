namespace Application.Products.Dtos;

/// <summary>
/// Data transfer object return Product.
/// </summary>
public class ProductToReturnDto
{
    public string? Name { get; init; }
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public string? ProductType { get; init; }
    public string? ProductBrand { get; init; }
}