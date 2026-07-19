using Microsoft.AspNetCore.Mvc;

namespace Discount.Api
{
    public static class ApiServicesRegisteration
    {
        public static void ConfigureApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddOpenApi();
        }
    }
}
