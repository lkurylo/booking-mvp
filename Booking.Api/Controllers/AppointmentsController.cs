using Booking.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers;

public class AppointmentsController(IMediator mediator): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Book(BookAppointmentCommand command)
    {
        var id = await mediator.Send(command);

        return Ok(new { AppointmentId = id });
    }
}