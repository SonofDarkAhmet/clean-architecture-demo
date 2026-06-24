using MediatR;
using CleanArchitecture.Domain.DTOs;

namespace CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

public sealed record CreateRoleCommand(
    string Name
): IRequest<MessageResponse>;
