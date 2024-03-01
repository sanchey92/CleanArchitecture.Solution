using Application.Loggers;
using Domain.Abstractions;

namespace Root.Extensions;

/// <summary>
/// Extension methods for configuring logging services.
/// </summary>
internal static class ServicesExtensions
{
    /// <summary>
    /// Adds custom logger configuration to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> after the operation.</returns>
    public static IServiceCollection AddLoggerConfiguration(this IServiceCollection services)
    {
        services.AddSingleton<ICustomLogger, CustomLogger>();
        return services;
    }

    /// <summary>
    /// Adds CORS (Cross-Origin Resource Sharing) configuration to the service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> after the operation.</returns>
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod();
            });
        });

        return services;
    }
}