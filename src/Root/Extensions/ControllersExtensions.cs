namespace Root.Extensions;

/// <summary>
/// Extension methods for configuring controllers in the service collection.
/// </summary>
internal static class ControllersExtensions
{
    /// <summary>
    /// Adds configuration for controllers to the service collection.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddControllersConfiguration(this IServiceCollection services)
    {
        // Reference to the assembly containing controllers
        var presentationAssembly = typeof(Presentation.Controllers.AssemblyReference).Assembly;

        services.AddControllers(configuration =>
            {
                // Enable respect for browser accept header and return HTTP not acceptable when required
                configuration.RespectBrowserAcceptHeader = true;
                configuration.ReturnHttpNotAcceptable = true;
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                // Suppress the ModelStateInvalidFilter to handle validation errors manually
                options.SuppressModelStateInvalidFilter = true;
            })
            // Uncomment the following line to add XML data contract serializer formatters
            // .AddXmlDataContractSerializerFormatters()
            .AddApplicationPart(presentationAssembly);

        return services;
    }
}
