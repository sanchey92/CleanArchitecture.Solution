namespace Application.RequestFeatures;

/// <summary>
/// Represents the parameters for paginated requests.
/// </summary>
public abstract class RequestParameters
{
    private const int MaxPageSize = 10;
    private int _pageSize = 3;

    /// <summary>
    /// Gets or sets the page index.
    /// </summary>
    public int PageIndex { get; set; } = 1;

    /// <summary>
    /// Gets or sets the page size with a maximum limit of <see cref="MaxPageSize"/>.
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }

    /// <summary>
    /// Gets or sets the requested fields for filtering.
    /// </summary>
    public string? Fields { get; init; }
}