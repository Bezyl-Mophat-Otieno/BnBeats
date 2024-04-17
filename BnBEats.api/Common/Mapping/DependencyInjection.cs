using System.Reflection;
using Mapster;
using MapsterMapper;
namespace BnBEats.api
{
    public static class DependencyInjectionMappings
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();
            return services;
        }
    }
}
