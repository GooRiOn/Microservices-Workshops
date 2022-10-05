using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MySpot.Services.Reservations.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}