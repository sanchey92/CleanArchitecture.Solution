using Domain.Primitives;

namespace Domain.Entity;

/// <summary>
/// Represents a product type entity.
/// </summary>
public sealed class ProductType : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the product type.
    /// </summary>
    public string? Name { get; set; }
}