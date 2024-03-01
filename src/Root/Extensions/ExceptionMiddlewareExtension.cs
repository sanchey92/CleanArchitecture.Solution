using Domain.Abstractions;
using Domain.Exceptions.Base;
using Domain.Primitives;
using Microsoft.AspNetCore.Diagnostics;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Root.Extensions;

/// <summary>
/// Extension methods for configuring exception handling middleware in an ASP.NET Core application.
/// </summary>
internal static class ExceptionMiddlewareExtension
{
    /// <summary>
    /// Configures exception handling middleware for the specified web application.
    /// </summary>
    /// <param name="application">The web application instance.</param>
    /// <param name="logger">The logger instance</param>
    /// <returns>The configured web application instance.</returns>
    public static WebApplication ConfigureExceptionHandler(this WebApplication application, ICustomLogger logger)
    {
        application.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        BadRequestException => StatusCodes.Status400BadRequest,
                        ValidationApiException => StatusCodes.Status422UnprocessableEntity,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    logger.LoggerError($"Error Details: {contextFeature.Error}");

                    if (contextFeature.Error is ValidationApiException exception)
                    {
                        await context.Response
                            .WriteAsync(JsonSerializer.Serialize(new { exception.Errors }));
                    }
                    else
                    {
                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                }
            });
        });

        return application;
    }
}