using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FMI.Gateways.Data.Contexts;

namespace FMI.Gateways.Services.Extensions
{
    public static class Extensions
    {
        public static void ConfigureContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<GatewaysContext>(x => config.GetConnectionString("Gateways"));
        }
    }
}