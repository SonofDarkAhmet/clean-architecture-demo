using CleanArchitecture.WebApi.Configurations.Abstractions;
using CleanArchitecture.WebApi.OptionsSetup;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Application;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.WebApi.Configurations;

public sealed class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration, IHostBuilder host)
    {
        services.AddScoped<IUserProvider<User>, UserProvider>();

        services.AddScoped<IJwtProvider, JwtProvider>();

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();
    }
}