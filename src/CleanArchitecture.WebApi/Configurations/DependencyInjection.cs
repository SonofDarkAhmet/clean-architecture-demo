
using System.Reflection;
using CleanArchitecture.WebApi.Configurations.Abstractions;

namespace CleanArchitecture.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection InstallServices(
        this IServiceCollection services,
        IConfiguration configuration,
        params Assembly[] assemblies)
    {
        IEnumerable<IServiceInstaller> serviceInstallers = assemblies
            .SelectMany(s => s.DefinedTypes)
            .Where(IsAssignableToType<IServiceInstaller>)
            .Select(type => (IServiceInstaller)Activator.CreateInstance(type.AsType())!);

        foreach (IServiceInstaller serviceInstaller in serviceInstallers)
        {
            serviceInstaller.Install(services, configuration);
        }

        return services;

        static bool IsAssignableToType<T>(TypeInfo typeInfo)
            => typeof(T).IsAssignableFrom(typeInfo) &&
               !typeInfo.IsInterface &&
               !typeInfo.IsAbstract;
    }
}
