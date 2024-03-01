using Domain.Abstractions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using Root.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

LogManager.Setup()
    .LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

#region ConfigureServices

builder.Services.AddLoggerConfiguration();
builder.Services.AddCorsConfiguration();
builder.Services.AddVersioningConfiguration();
builder.Services.AddControllersConfiguration();
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(configuration);
builder.Services.AddSwaggerConfiguration();

#endregion

var app = builder.Build();

#region ConfigureApplication

var logger = app.Services.GetRequiredService<ICustomLogger>();

if (app.Environment.IsProduction()) app.UseHsts();

app.ConfigureExceptionHandler(logger);
app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Your application name"));
}

app.UseStaticFiles();
app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

#endregion

app.Run();