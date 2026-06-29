using FluentValidation;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;

public sealed class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Car name cannot be empty!");
        RuleFor(p => p.Name).NotNull().WithMessage("Car name cannot be empty!");
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("Car name must be at least three characters!");

        RuleFor(p => p.Model).NotEmpty().WithMessage("Car model cannot be empty!");
        RuleFor(p => p.Model).NotNull().WithMessage("Car model cannot be empty!");
        RuleFor(p => p.Model).MinimumLength(3).WithMessage("Car model must be at least three characters!");

        RuleFor(p => p.EnginePower).NotEmpty().WithMessage("Car engine power cannot be empty!");
        RuleFor(p => p.EnginePower).NotNull().WithMessage("Car engine power cannot be empty!");
        RuleFor(p => p.EnginePower).GreaterThan(0).WithMessage("Car engine power must be greater than 0!");
    }
}
