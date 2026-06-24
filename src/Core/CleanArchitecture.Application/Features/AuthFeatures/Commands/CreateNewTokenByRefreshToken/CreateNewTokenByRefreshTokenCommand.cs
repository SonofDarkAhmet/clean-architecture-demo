using MediatR;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;


public sealed record CreateNewTokenByRefreshTokenCommand(
    string UserId,
    string RefreshToken
): IRequest<LoginCommandResponse>;
