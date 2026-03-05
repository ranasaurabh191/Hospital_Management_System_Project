using Hospital.Application.Services;
using Hospital.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers;

[ApiController]
[Route("api/appointments")]
public class AppointmentsController : ControllerBase
{
    private readonly AppointmentService _service;

    public AppointmentsController(AppointmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var appointments = _service.GetAppointments();
            return Ok(appointments);
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult Add(Appointment appointment)
    {
        _service.AddAppointment(appointment);
        return Ok();
    }
}