using CleanArchitecture.WebApi.Configurations.Abstractions;

namespace CleanArchitecture.WebApi.Configurations;

public class AuthorizeServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication().AddJwtBearer();
        services.AddAuthorization();
    }
}
