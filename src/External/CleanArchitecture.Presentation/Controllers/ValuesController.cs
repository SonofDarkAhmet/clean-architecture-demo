using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Test api operation is successful!");
    }
}