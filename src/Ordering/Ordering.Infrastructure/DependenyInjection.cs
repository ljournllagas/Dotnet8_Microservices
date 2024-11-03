using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;
public static class DependenyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services
        ,IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");



        return services;
    }
}
