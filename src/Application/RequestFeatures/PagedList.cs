namespace Application.RequestFeatures;

/// <summary>
/// Represents a paginated list with metadata.
/// </summary>
/// <typeparam name="T">Type of the items in the list.</typeparam>
public sealed class PagedList<T> : List<T> where T : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
    /// </summary>
    /// <param name="items">The collection of items in the current page.</param>
    /// <param name="count">The total count of items across all pages.</param>
    /// <param name="currentPage">The current page index.</param>
    /// <param name="pageSize">The number of items per page.</param>
    public PagedList(IEnumerable<T> items, int count, int currentPage, int pageSize)
    {
        MetaData = new MetaData(currentPage, pageSize, count);
        AddRange(items);
    }

    /// <summary>
    /// Gets or sets the metadata for the paginated list.
    /// </summary>
    public MetaData MetaData { get; set; }
}