using CS.Auth.Application.Services.Implementation;
using CS.Auth.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace CS.Auth.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}