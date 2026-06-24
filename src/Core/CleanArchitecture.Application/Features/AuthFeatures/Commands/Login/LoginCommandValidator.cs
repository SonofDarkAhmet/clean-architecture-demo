using FluentValidation;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

public sealed class LoginCommandValidator: AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Kullanici adi yada mail bilgisi bos olamaz!");
        RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Kullanici adi yada mail bilgisi  bos olamaz!");
        RuleFor(p => p.UserNameOrEmail).MinimumLength(3).WithMessage("Kullanici adi yada mail bilgisi en az uc karakter olmalidir!");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Sifre bos olamaz!");
        RuleFor(p => p.Password).NotNull().WithMessage("Sifre bos olamaz!");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Sifre en az 1 adet buyuk harf icermelidir!");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Sifre en az 1 adet kucuk harf icermelidir!");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Sifre en az 1 adet rakam icermelidir!");
        RuleFor(p => p.Password).Matches("[a-zA-Z0-9]").WithMessage("Sifre en az 1 adet ozel karakter icermelidir!");
    }

}