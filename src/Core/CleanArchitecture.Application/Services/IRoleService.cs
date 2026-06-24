using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

namespace CleanArchitecture.Application.Services;

public interface IRoleService
{
    // No need to send cancellation token since it is provided by RoleManager behind the scene
    Task CreateAsync(CreateRoleCommand request);
}
