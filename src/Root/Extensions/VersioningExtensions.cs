using Asp.Versioning;

namespace Root.Extensions;

/// <summary>
/// Extension methods for configuring API versioning in the ASP.NET Core Web API.
/// </summary>
internal static class VersioningExtensions
{
    /// <summary>
    /// Adds API versioning to the specified collection of services with the provided options.
    /// </summary>
    /// <param name="services">The collection of services to add API versioning to.</param>
    /// <returns>The modified collection of services.</returns>
    public static IServiceCollection AddVersioningConfiguration(this IServiceCollection services)
    {
        // Configure API versioning options
        services.AddApiVersioning(options =>
        {
            // Enables the reporting of supported API versions in the response headers
            options.ReportApiVersions = true;

            // Assumes the default API version when none is specified by the client
            options.AssumeDefaultVersionWhenUnspecified = true;

            // Sets the default API version to 1.0
            options.DefaultApiVersion = new ApiVersion(1, 0);

            // Additional API versioning options can be configured here
            // options.ApiVersionReader = ...;
            // options.ErrorResponses = ...;
            // ... and more
        });
        
        return services;
    }
}
