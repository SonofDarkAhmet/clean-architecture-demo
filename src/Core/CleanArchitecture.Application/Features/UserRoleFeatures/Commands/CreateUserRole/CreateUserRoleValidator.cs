using FluentValidation;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public class CreateUserRoleValidator : AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleValidator()
    {
        RuleFor(p => p.RoleId).NotEmpty().WithMessage("UserId adi bos olamaz!");
        RuleFor(p => p.RoleId).NotNull().WithMessage("UserId bos olamaz!");

        RuleFor(p => p.UserId).NotEmpty().WithMessage("UserId bos olamaz!");
        RuleFor(p => p.UserId).NotNull().WithMessage("UserId modeli bos olamaz!");
    }
}

