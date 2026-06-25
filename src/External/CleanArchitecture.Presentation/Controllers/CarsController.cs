using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Infrastructure.Authorization;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Presentation.Abstraction;
using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CleanArchitecture.Presentation.Controllers;

public sealed class CarsController : ApiController
{
    public CarsController(IMediator mediator) : base(mediator){}

    //[TypeFilter(typeof(RoleAttribute), FixedArgumentsEncoder = new Object[] {"Create"})] -> A cleaner option available
    [RoleFilter("Create")]
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCarCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [RoleFilter("GetAll")]
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllCarQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Car> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
