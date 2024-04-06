using BnBEats.application;
using Microsoft.Extensions.DependencyInjection;

namespace BnBEats.infrastructure;
using Microsoft.Extensions.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenarator>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.Configure<JwtSettings>(options =>
        {
            configuration.GetSection(JwtSettings.sectionName).Bind(options);
        });
        return services;
    }

}
