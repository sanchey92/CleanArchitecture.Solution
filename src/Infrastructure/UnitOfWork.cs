using Domain.Abstractions;
using Domain.Primitives;
using Infrastructure.Repositories;

namespace Infrastructure;

/// <summary>
/// Represents a unit of work pattern implementation for managing repositories.
/// </summary>
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    private Dictionary<string, object> _repositories;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="dbContext">The application database context.</param>
    public UnitOfWork(ApplicationDbContext dbContext) => _dbContext = dbContext;

    /// <inheritdoc/>
    public void Dispose() => _dbContext.Dispose();

    /// <inheritdoc/>
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    /// <inheritdoc/>
    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        _repositories ??= new Dictionary<string, object>();

        var entityType = typeof(TEntity).Name;

        if (!_repositories.TryGetValue(entityType, out var repository))
        {
            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance =
                Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);

            repository = repositoryInstance ?? throw new InvalidOperationException("Failed to create repository");

            _repositories[entityType] = repository;
        }

        return repository as IGenericRepository<TEntity> ??
               throw new InvalidOperationException("Repository cast failed");
    }
}