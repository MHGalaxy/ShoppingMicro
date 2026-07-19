using Discount.Application.Queries.Discount;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Discount.Application;

public static class ApplicationServicesRegisteration
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        // Register MediatR
        var assemblies = new Assembly[]
        {
            Assembly.GetExecutingAssembly(),
            typeof(GetDiscountByProductNameQueryHandler).Assembly
        };

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssemblies(assemblies);
        });

        // Register Mapster with DI
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        // Register Grpc
        services.AddGrpc();
    }
}
