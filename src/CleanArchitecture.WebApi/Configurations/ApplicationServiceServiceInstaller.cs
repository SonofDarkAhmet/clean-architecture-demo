using CleanArchitecture.WebApi.Configurations.Abstractions;
using CleanArchitecture.Application.Behaviors;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.WebApi.Configurations;

public class ApplicationServiceServiceInstaller : IServiceInstaller
{
        public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfr => cfr.RegisterServicesFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly);
    }

}
