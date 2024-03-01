using Application.Behaviors;
using FluentValidation;
using MediatR;

namespace Root.Extensions;

/// <summary>
/// Extension methods for configuring the application layer in the service collection.
/// </summary>
internal static class ApplicationLayerConfiguration
{
    /// <summary>
    /// Adds configuration for the application layer to the service collection.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        // Get the assembly reference for the application layer
        var applicationAssembly = typeof(Application.AssemblyReference).Assembly;

        // Add MediatR and register services from the application assembly
        services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));

        // Add AutoMapper with the application assembly
        services.AddAutoMapper(applicationAssembly);

        // Add validation behavior for MediatR
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // Add validators from the application assembly
        services.AddValidatorsFromAssembly(applicationAssembly);

        return services;
    }
}
