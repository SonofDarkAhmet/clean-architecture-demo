using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

public class CreateNewTokenByRefreshTokenCommandValidator : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User Id information cannot be empty!");
        RuleFor(p => p.UserId).NotNull().WithMessage("User Id information cannot be empty!");

        RuleFor(p => p.RefreshToken).NotEmpty().WithMessage("Token information cannot be empty!");
        RuleFor(p => p.RefreshToken).NotNull().WithMessage("Token information cannot be empty!");
    }
}