using AppointmentBookingSystem.Application.DTOs;
using AppointmentBookingSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentBookingSystem.API.Controllers;

[ApiController]
[Route("calendar")]
public class CalendarController : ControllerBase
{
	private readonly IAppointmentService _appointmentService;

	public CalendarController(IAppointmentService appointmentService)
	{
		_appointmentService = appointmentService;
	}

	[HttpPost("query")]
	public async Task<IActionResult> GetAvailableSlots([FromBody] AppointmentQueryDto query)
	{
		var slots = await _appointmentService.GetAvailableSlotsAsync(query);
		return Ok(slots);
	}
}
