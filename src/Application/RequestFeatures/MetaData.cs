namespace Application.RequestFeatures;

/// <summary>
/// Represents metadata information about a paginated result,
/// including details about the current page, page size, total count, and total pages.
/// </summary>
public sealed class MetaData
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MetaData"/> class with the specified pagination details.
    /// </summary>
    /// <param name="currentPage">The current page number.</param>
    /// <param name="pageSize">The size of each page.</param>
    /// <param name="totalCount">The total number of items.</param>
    public MetaData(int currentPage, int pageSize, int totalCount)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = totalCount;
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    }

    /// <summary>
    /// Gets the current page number.
    /// </summary>
    public int CurrentPage { get; init; }

    /// <summary>
    /// Gets the total number of pages.
    /// </summary>
    public int TotalPages { get; init; }

    /// <summary>
    /// Gets the size of each page.
    /// </summary>
    public int PageSize { get; init; }

    /// <summary>
    /// Gets the total number of items.
    /// </summary>
    public int TotalCount { get; init; }

    /// <summary>
    /// Gets a value indicating whether there is a previous page.
    /// </summary>
    public bool HasPrevious => CurrentPage > 1;

    /// <summary>
    /// Gets a value indicating whether there is a next page.
    /// </summary>
    public bool HasNext => CurrentPage < TotalPages;
}