using FluentValidation;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;

public sealed class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Arac adi bos olamaz!");
        RuleFor(p => p.Name).NotNull().WithMessage("Arac adi bos olamaz!");
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("Arac adi en az uc karakter olmalidir!");

        RuleFor(p => p.Model).NotEmpty().WithMessage("Arac modeli bos olamaz!");
        RuleFor(p => p.Model).NotNull().WithMessage("Arac modeli bos olamaz!");
        RuleFor(p => p.Model).MinimumLength(3).WithMessage("Arac adi en az uc karakter olmalidir!");

        RuleFor(p => p.EnginePower).NotEmpty().WithMessage("Arac motor gucu bos olamaz!");
        RuleFor(p => p.EnginePower).NotNull().WithMessage("Arac motor gucu bos olamaz!");
        RuleFor(p => p.EnginePower).GreaterThan(0).WithMessage("Arac motor gucu 0'dan buyuk olmalidir!");
    }
}
