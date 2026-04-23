using System.Reflection;
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
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            // Add pipeline behaviors(optional)
            // cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            // cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        // Register Mapster with DI
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        // OR using Mapster.DependencyInjection extension method
        //services.AddMapster(Assembly.GetExecutingAssembly());
        //services.AddMapster(); ???

        // Register validators (if using FluentValidation)
        // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    }
}