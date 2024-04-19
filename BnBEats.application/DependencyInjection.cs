using BnBEata.application.Services.Authentication;
using BnBEats.application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BnBEata.application;



public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, Services.Authentication.Commands.Register.AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        return services;
    }
}