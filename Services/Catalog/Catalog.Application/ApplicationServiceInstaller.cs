using System.Reflection;
using Catalog.Application.Queries.Product;

//using Catalog.Application.Behaviors;
using Catalog.Core.Abstractions;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Application;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
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