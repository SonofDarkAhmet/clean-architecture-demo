using CleanArchitecture.WebApi.Configurations.Abstractions;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Persistance.Services;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.WebApi.Middleware;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Repositories;
using CleanArchitecture.Persistance.Context;
using GenericRepository;

namespace CleanArchitecture.WebApi.Configurations;

public sealed class PersistanceDIServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        
        services.AddTransient<ExceptionMiddleware>();
        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<AppDbContext>());
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
    }
}
