using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Presentation.Abstraction;
using CleanArchitecture.Application.Features.RoleFeatures.Commands.CreateRole;

namespace CleanArchitecture.Presentation.Controllers;

public sealed class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Create(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
