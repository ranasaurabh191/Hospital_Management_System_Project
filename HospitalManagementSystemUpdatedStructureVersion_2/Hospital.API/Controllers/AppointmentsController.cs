using Hospital.Application.Services;
using Hospital.Domain.Entities;
using Hospital.Domain.Exceptions;
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
        try
        {
            _service.AddAppointment(appointment);
            return Ok("Appointment created successfully.");
        }
        catch (DoctorNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (PatientNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}