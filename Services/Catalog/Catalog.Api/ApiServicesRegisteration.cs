using Catalog.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api;

public static class ApiServicesRegisteration
{
    public static void ConfigureApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddAuthorization();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        //Create document of swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo { Title = "Catalog.Api", Version = "v1", Description = "Catalog API" });
        }); 

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

        // Add Response Caching if needed
        services.AddResponseCaching();

        // Add Problem Details for better API error responses
        services.AddProblemDetails();
    }
}