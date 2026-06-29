using MediatR;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;
using System.Net;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

public sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, MessageResponse>
{
    private readonly IRoleService _roleService;
    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<MessageResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        await _roleService.CreateAsync(request);
        return new("Role record completed successfully!");
    }
}

