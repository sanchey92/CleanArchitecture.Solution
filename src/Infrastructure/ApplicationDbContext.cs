using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

/// <summary>
/// Represents the database context for the application, providing access to the entities and their relationships.
/// </summary>
public sealed class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The options to be used by the context.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Configures the model using the fluent API. This method is called for each instance of the context
    /// that is created by the Entity Framework.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        // Other configurations...

        // Applies a UTC date-time converter to all date-time properties of entities.
        modelBuilder.ApplyUtcDateTimeConverter();
    }
}