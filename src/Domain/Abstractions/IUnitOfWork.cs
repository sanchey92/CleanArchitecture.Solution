using Domain.Primitives;

namespace Domain.Abstractions;

/// <summary>
/// Defines the interface for a Unit of Work pattern, providing access to repositories
/// and the ability to save changes asynchronously.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Gets a repository for the specified entity type.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <returns>An instance of the generic repository for the specified entity type.</returns>
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

    /// <summary>
    /// Saves changes made in the unit of work asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous save operation.</returns>
    Task<int> SaveChangesAsync();
}