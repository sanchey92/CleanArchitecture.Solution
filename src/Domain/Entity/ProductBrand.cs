using Domain.Primitives;

namespace Domain.Entity;

/// <summary>
/// Represents a product brand entity.
/// </summary>
public sealed class ProductBrand : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the product brand.
    /// </summary>
    public string? Name { get; set; }
}
