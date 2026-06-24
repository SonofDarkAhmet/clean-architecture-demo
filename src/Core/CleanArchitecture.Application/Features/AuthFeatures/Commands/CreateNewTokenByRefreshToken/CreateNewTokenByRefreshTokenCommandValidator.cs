using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

public class CreateNewTokenByRefreshTokenCommandValidator : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("Kullanici Id no bilgisi bos olamaz!");
        RuleFor(p => p.UserId).NotNull().WithMessage("Kullanici Id no bilgisi  bos olamaz!");
        
        RuleFor(p => p.RefreshToken).NotEmpty().WithMessage("Token bilgisi bos olamaz!");
        RuleFor(p => p.RefreshToken).NotNull().WithMessage("Token bilgisi  bos olamaz!");        
    }
}