using System.Linq.Expressions;
using Domain.Primitives;

namespace Domain.Abstractions;

public interface ISpecification<TEntity> where TEntity : BaseEntity 
{
    /// <summary>
    /// Gets or sets the criteria expression for filtering entities.
    /// </summary>
    Expression<Func<TEntity, bool>>? Criteria { get; }

    /// <summary>
    /// Gets or sets the list of include expressions for eager loading related entities.
    /// </summary>
    List<Expression<Func<TEntity, object>>>? Includes { get; }

    /// <summary>
    /// Gets or sets the order by expression for sorting entities in ascending order.
    /// </summary>
    Expression<Func<TEntity, object>>? OrderBy { get; }

    /// <summary>
    /// Gets or sets the order by descending expression for sorting entities in descending order.
    /// </summary>
    Expression<Func<TEntity, object>>? OrderByDescending { get; }

    /// <summary>
    /// Gets the number of entities to take in the result set.
    /// </summary>
    int Take { get; }

    /// <summary>
    /// Gets the number of entities to skip in the result set.
    /// </summary>
    int Skip { get; }

    /// <summary>
    /// Gets a value indicating whether paging is enabled for the query.
    /// </summary>
    bool IsPagingEnabled { get; }
}
