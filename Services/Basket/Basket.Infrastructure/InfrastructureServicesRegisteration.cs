using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Infrastructure;

public static class InfrastructureServicesRegisteration
{
    public static void ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            // The configuration will be read from appsettings.json
            options.Configuration = configuration.GetConnectionString("Redis");
            // An optional instance name to prefix your cache keys
            options.InstanceName = "MyApp_";
        });
    }
}
