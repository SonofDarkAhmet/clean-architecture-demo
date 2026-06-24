using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

namespace CleanArchitecture.Application.Abstractions;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateTokenAsync(User user);
}
