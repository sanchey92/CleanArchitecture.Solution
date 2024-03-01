using Domain.Abstractions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Root.Extensions;

/// <summary>
/// Extension methods for configuring the infrastructure layer in the service collection.
/// </summary>
internal static class InfrastructureLayerConfiguration
{
    /// <summary>
    /// Adds configuration for the infrastructure layer to the service collection.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The configuration containing connection strings.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Get the PostgreSQL connection string from configuration
        var connectionString = configuration.GetConnectionString("PostgresConnection");

        // Add the ApplicationDbContext with PostgreSQL
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

        // Add the UnitOfWork to the service collection
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
