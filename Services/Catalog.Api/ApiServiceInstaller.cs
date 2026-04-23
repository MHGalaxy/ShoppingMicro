using Catalog.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api;

public class ApiServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        // Register Controllers
        services.AddControllers();

        // Register API Versioning
        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
        });

        // Register CORS if needed
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        // Register Health Checks (if you want to expose health endpoints)
        services.AddHealthChecks();

        // Add API Explorer
        services.AddEndpointsApiExplorer();

        // Add Response Caching if needed
        services.AddResponseCaching();

        // Add Problem Details for better API error responses
        services.AddProblemDetails();
    }
}