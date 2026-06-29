using AutoMapper;
using CleanArchitecture.Application;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CleanArchitecture.Persistance.Services;

public sealed class AuthService : IAuthService
{
    private readonly IUserProvider<User> _userProvider;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly IJwtProvider _jwtProvider;

    public AuthService(IUserProvider<User> userProvider, IMapper mapper, IMailService mailService, IJwtProvider jwtProvider)
    {
        _userProvider = userProvider;
        _mapper = mapper;
        _mailService = mailService;
        _jwtProvider = jwtProvider;
    }

    public async Task RegisterAsync(RegisterCommand request)
    {
        User user = _mapper.Map<User>(request);
        IdentityResultModel result = await _userProvider.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First());
        }

        /* Activate after having a valid stmp server
        List<string> emails = new();
        emails.Add(request.Email);
        string subject = "Mail Confirmation"
        string body = "Mail has been confirmed successfully."
        await _mailService.SendMailAsync(emails, subject, body); 
        */
    }

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userProvider.FindByUserNameOrEmailAsync(request.UserNameOrEmail, cancellationToken);

        if (user == null) throw new Exception("User not found!");

        var result = await _userProvider.CheckPasswordAsync(user, request.Password);
        if (result)
        {
            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
            return response;
        }

        throw new Exception("You entered the wrong password!");
    }

    public async Task<LoginCommandResponse> CreateTokenByRefreshAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        User user = await _userProvider.FindByIdAsync(request.UserId, cancellationToken);

        if (user == null) throw new Exception("User not found!");

        if (user.RefreshToken != request.RefreshToken) throw new Exception("Refresh Token is not valid!");

        if (user.RefreshTokenExpires < DateTime.Now) throw new Exception("Refresh Token has expired!");

        LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);

        return response;
    }
}
