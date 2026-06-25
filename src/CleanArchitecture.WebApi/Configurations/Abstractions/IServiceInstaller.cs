namespace CleanArchitecture.WebApi.Configurations.Abstractions;

public interface IServiceInstaller
{
    void Install(IServiceCollection services, IConfiguration configuration);
}
