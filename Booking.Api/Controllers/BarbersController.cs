using Booking.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BarbersController(IMediator mediator) : ControllerBase
{
    [HttpGet("load")]
    public async Task<IActionResult> GetBarbers()
    {
        var barbers = await mediator.Send(new ListBarbersQuery());

        return Ok(barbers);
    }
}