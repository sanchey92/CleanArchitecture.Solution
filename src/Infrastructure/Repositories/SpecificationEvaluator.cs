using Domain.Abstractions;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// A utility class for evaluating specifications on IQueryable data.
/// </summary>
/// <typeparam name="TEntity">The type of entities being queried.</typeparam>
internal sealed class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Gets a queryable representation of entities based on the provided specification.
    /// </summary>
    /// <param name="inputQuery">The original queryable data.</param>
    /// <param name="specification">The specification to apply to the query.</param>
    /// <returns>A queryable representation of entities based on the specification.</returns>
    public static IQueryable<TEntity> GetQuery(
        IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
    {
        var query = inputQuery;

        if (specification.Criteria != null)
            query = query.Where(specification.Criteria);

        if (specification.OrderBy != null)
            query = query.OrderBy(specification.OrderBy);

        if (specification.OrderByDescending != null)
            query = query.OrderByDescending(specification.OrderByDescending);

        if (specification.IsPagingEnabled)
            query = query.Skip(specification.Skip).Take(specification.Take);

        query = specification.Includes!.Aggregate(query, 
            (current, include) => current.Include(include));

        return query;
    }
}
