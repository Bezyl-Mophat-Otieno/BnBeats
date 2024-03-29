using Microsoft.Extensions.DependencyInjection;

namespace BnBEata.infrastucture;



public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}