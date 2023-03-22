using CS.Auth.Application.Contracts;
using CS.Auth.Infrastructure.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace CS.Auth.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}