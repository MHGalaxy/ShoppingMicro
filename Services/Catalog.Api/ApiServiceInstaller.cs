using Catalog.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api;

public class ApiServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();

        // Register Controllers
        services.AddControllers();

        services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo { Title = "Catalog.Api", Version = "v1", Description = "Catalog API" });
        }); //Create document of swagger

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