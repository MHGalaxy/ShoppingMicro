using Basket.Application.Queries.Basket;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Basket.Application;

public static class ApplicationServicesRegisteration
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        // Register MediatR
        var assemblies = new Assembly[]
        {
            Assembly.GetExecutingAssembly(),
            typeof(GetBasketByUserNameQueryHandler).Assembly
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
