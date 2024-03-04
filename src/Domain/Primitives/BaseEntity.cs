namespace Domain.Primitives;

/// <summary>
/// Represents the base entity in the application with an identifier.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BaseEntity"/> class
    /// with the specified identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    protected BaseEntity(Guid id) => Id = id;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseEntity"/> class.
    /// </summary>
    protected BaseEntity()
    {
    }

    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public Guid Id { get; init; }
}
