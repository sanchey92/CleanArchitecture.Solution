namespace Application.RequestFeatures;

/// <summary>
/// Parameters for filtering and paging products.
/// </summary>
public sealed class ProductsRequestParams : RequestParameters
{
    private string _search;

    /// <summary>
    /// Gets or sets the search string.
    /// </summary>
    public string Search
    {
        get => _search;
        set => _search = value.ToLower();
    }

    /// <summary>
    /// Gets the sort order.
    /// </summary>
    public string? Sort { get; set; }

    /// <summary>
    /// Gets or the product type ID for filtering.
    /// </summary>
    public Guid? TypeId { get; set; }

    /// <summary>
    /// Gets the product brand ID for filtering.
    /// </summary>
    public Guid? BrandId { get; set; }
}