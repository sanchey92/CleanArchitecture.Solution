using Domain.Primitives;

namespace Domain.Abstractions;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Retrieves an entity by its unique identifier asynchronously.
    /// </summary>
    Task<TEntity?> GetByIdAsync(Guid id, bool trackChanges = false);

    /// <summary>
    /// Retrieves all entities of the specified type asynchronously.
    /// </summary>
    Task<IReadOnlyList<TEntity>> GetAllAsync(bool trackChanges = false);

    /// <summary>
    /// Retrieves a single entity based on the provided specification asynchronously.
    /// </summary>
    Task<TEntity?> GetSingleWithSpecificationAsync(ISpecification<TEntity> specification,
        bool trackChanges = false);

    /// <summary>
    /// Retrieves a list of entities based on the provided specification asynchronously.
    /// </summary>
    Task<IReadOnlyList<TEntity>> GetListWithSpecificationAsync(ISpecification<TEntity> specification,
        bool trackChanges = false);

    /// <summary>
    /// Counts the total number of entities.
    /// </summary>
    Task<int> CountAsync();

    /// <summary>
    /// Counts the number of entities based on the provided specification.
    /// </summary>
    Task<int> CountWithSpecificationAsync(ISpecification<TEntity> specification);

    /// <summary>
    /// Adds a new entity to the repository asynchronously.
    /// </summary>
    Task AddAsync(TEntity entity);

    /// <summary>
    /// Updates the specified entity in the repository.
    /// </summary>
    void Update(TEntity entity);

    /// <summary>
    /// Deletes the specified entity from the repository.
    /// </summary>
    void Delete(TEntity entity);
}
