using System.Linq.Expressions;
using Domain.Abstractions;
using Domain.Primitives;

namespace Application.Specifications;

/// <summary>
/// Base class for specifications that define criteria, includes, ordering, and paging.
/// </summary>
/// <typeparam name="TEntity">Type of the entity the specification is for.</typeparam>
public abstract class BaseSpecification<TEntity> : ISpecification<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseSpecification{TEntity}"/> class with the specified criteria.
    /// </summary>
    /// <param name="criteria">The criteria expression.</param>
    protected BaseSpecification(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }

    /// <inheritdoc/>
    public Expression<Func<TEntity, bool>> Criteria { get; }

    /// <inheritdoc/>
    public List<Expression<Func<TEntity, object>>>? Includes { get; } = new List<Expression<Func<TEntity, object>>>();

    /// <inheritdoc/>
    public Expression<Func<TEntity, object>>? OrderBy { get; private set; }

    /// <inheritdoc/>
    public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }

    /// <inheritdoc/>
    public int Take { get; private set; }

    /// <inheritdoc/>
    public int Skip { get; private set; }

    /// <inheritdoc/>
    public bool IsPagingEnabled { get; private set; }

    /// <summary>
    /// Adds an include expression to the specification.
    /// </summary>
    /// <param name="expression">The include expression.</param>
    public void AddInclude(Expression<Func<TEntity, object>> expression) => Includes!.Add(expression);

    /// <summary>
    /// Adds an order by expression to the specification.
    /// </summary>
    /// <param name="expression">The order by expression.</param>
    public void AddOrderBy(Expression<Func<TEntity, object>> expression) => OrderBy = expression;

    /// <summary>
    /// Adds an order by descending expression to the specification.
    /// </summary>
    /// <param name="expression">The order by descending expression.</param>
    public void AddOrderByDescending(Expression<Func<TEntity, object>> expression) => OrderByDescending = expression;

    /// <summary>
    /// Applies paging to the specification.
    /// </summary>
    /// <param name="skip">The number of items to skip.</param>
    /// <param name="take">The number of items to take.</param>
    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }
}