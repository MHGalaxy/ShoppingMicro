using System.Reflection;
using Catalog.Application.Queries.Product;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application;

public static class ApplicationServicesRegisteration
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        // Register MediatR
        var assemblies = new Assembly[]
        {
            Assembly.GetExecutingAssembly(),
            typeof(GetAllProductsQueryHandler).Assembly
        };

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssemblies(assemblies);
        });

        // Register Mapster with DI
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

    }
}