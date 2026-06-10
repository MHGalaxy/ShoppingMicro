using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public static class InfrastructureServicesRegisteration
{
    public static void ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoConnectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
        var mongoDatabaseName = configuration.GetValue<string>("DatabaseSettings:DatabaseName");

        services.AddSingleton<IMongoClient>(sp =>
            new MongoClient(mongoConnectionString));

        services.AddScoped(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            return client.GetDatabase(mongoDatabaseName);
        });

        // Register CatalogContext
        services.AddScoped<ICatalogContext, CatalogContext>();

        // Register Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
        services.AddScoped<IProductBrandRepository, ProductBrandRepository>();

        // Register MongoDB Health Check
        //services.AddHealthChecks()
        //    .AddMongoDb(
        //        mongodbConnectionString: mongoConnectionString,
        //        name: "MongoDB Health",
        //        failureStatus: HealthStatus.Unhealthy,
        //        tags: new[] { "database", "mongodb" }
        //    );

        // If you want to add more health checks
        // services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();
    }
}
