using Domain.Primitives;

namespace Domain.Entity;

/// <summary>
/// Represents a product entity.
/// </summary>
public sealed class Product : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the type of the product.
    /// </summary>
    public ProductType? ProductType { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the product type.
    /// </summary>
    public Guid ProductTypeId { get; set; }

    /// <summary>
    /// Gets or sets the brand of the product.
    /// </summary>
    public ProductBrand? ProductBrand { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the product brand.
    /// </summary>
    public Guid ProductBrandId { get; set; }
}