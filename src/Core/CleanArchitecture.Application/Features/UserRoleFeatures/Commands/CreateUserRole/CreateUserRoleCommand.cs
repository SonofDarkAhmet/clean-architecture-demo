using MediatR;
using CleanArchitecture.Domain.DTOs;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;


public sealed record CreateUserRoleCommand(
    string RoleId,
    string UserId
) : IRequest<MessageResponse>;