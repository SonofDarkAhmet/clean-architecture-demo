using MediatR;
using System.Net;
using CleanArchitecture.Domain.DTOs;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;

public sealed record RegisterCommand(
    string Email,
    string UserName,
    string NameLastName,
    string Password
): IRequest<MessageResponse>;
