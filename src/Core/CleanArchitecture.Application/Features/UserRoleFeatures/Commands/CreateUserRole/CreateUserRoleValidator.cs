using FluentValidation;
using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

public class CreateUserRoleValidator : AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleValidator()
    {
        RuleFor(p => p.RoleId).NotEmpty().WithMessage("RoleId cannot be empty!");
        RuleFor(p => p.RoleId).NotNull().WithMessage("RoleId cannot be empty!");

        RuleFor(p => p.UserId).NotEmpty().WithMessage("UserId cannot be empty!");
        RuleFor(p => p.UserId).NotNull().WithMessage("UserId cannot be empty!");
    }
}

