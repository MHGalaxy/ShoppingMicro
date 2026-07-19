using Discount.Core.Repositories;
using Discount.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Infrastructure;

public static class InfrastructureServicesRegisteration
{
    public static void ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register Repositories 
        services.AddScoped<IDiscountRepository, DiscountRepository>();
    }
}
