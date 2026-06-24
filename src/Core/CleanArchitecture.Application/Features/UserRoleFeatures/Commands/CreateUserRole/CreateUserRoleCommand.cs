using MediatR;
using CleanArchitecture.Domain.DTOs;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;


public sealed class CreateUserRoleCommand(
    string RoleId,
    string UserId
) : IRequest<MessageResponse>;