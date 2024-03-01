using Domain.Abstractions;
using Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// Represents a generic repository for entities of type <typeparamref name="TEntity"/>
/// in the application's data access layer.
/// </summary>
/// <typeparam name="TEntity">The type of entities managed by the repository.</typeparam>
internal sealed class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class
    /// with the specified database context.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    public GenericRepository(ApplicationDbContext context) => _context = context;

    /// <inheritdoc />
    public async Task<TEntity?> GetByIdAsync(Guid id, bool trackChanges = false)
    {
        return trackChanges
            ? await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id)
            : await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<TEntity>> GetAllAsync(bool trackChanges = false)
    {
        return trackChanges
            ? await _context.Set<TEntity>().ToListAsync()
            : await _context.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    /// <inheritdoc />
    public async Task<TEntity?> GetSingleWithSpecificationAsync(
        ISpecification<TEntity> specification, bool trackChanges = false)
    {
        return trackChanges
            ? await ApplySpecification(specification).FirstOrDefaultAsync()
            : await ApplySpecification(specification).AsNoTracking().FirstOrDefaultAsync();
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<TEntity>> GetListWithSpecificationAsync(
        ISpecification<TEntity> specification, bool trackChanges = false)
    {
        return trackChanges
            ? await ApplySpecification(specification).ToListAsync()
            : await ApplySpecification(specification).AsNoTracking().ToListAsync();
    }

    /// <inheritdoc />
    public async Task<int> CountWithSpecificationAsync(ISpecification<TEntity> specification)
    {
        return await ApplySpecification(specification).CountAsync();
    }

    /// <inheritdoc />
    public async Task<int> CountAsync()
    {
        return await _context.Set<TEntity>().CountAsync();
    }

    /// <inheritdoc />
    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    /// <inheritdoc />
    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    /// <inheritdoc />
    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    /// <summary>
    /// Applies the given specification to the entity set, constructing a query based on the provided criteria,
    /// includes, and ordering specifications.
    /// </summary>
    /// <param name="specification">An instance of the <see cref="ISpecification{TEntity}"/> representing the criteria,
    /// includes, and ordering specifications for querying the entities.</param>
    /// <returns>An <see cref="IQueryable{TEntity}"/> representing the result of applying the specification to the entity set,
    /// as a queryable collection of entities.</returns>
    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
    {
        return SpecificationEvaluator<TEntity>
            .GetQuery(_context.Set<TEntity>().AsQueryable(), specification);
    }
}