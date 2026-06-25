using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Presentation.Abstraction;
using CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole;

namespace CleanArchitecture.Presentation.Controllers;

public sealed class UserRolesController : ApiController
{
    public UserRolesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Create(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

}
