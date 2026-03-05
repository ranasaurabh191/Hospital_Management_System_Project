using Hospital.Application.Services;
using Hospital.Domain.Entities;
using Hospital.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers;

[ApiController]
[Route("api/doctors")]
public class DoctorsController : ControllerBase
{
    private readonly DoctorService _service;

    public DoctorsController(DoctorService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var doctors = _service.GetDoctors();
            return Ok(doctors);
        }
        catch (DoctorNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult Add(Doctor doctor)
    {
        _service.AddDoctor(doctor);
        return Ok();
    }

    [HttpGet("search/{name}")]
    public IActionResult Find(string name)
    {
        try
        {
            var doctor = _service.FindDoctor(name);
            return Ok(doctor);
        }
        catch (DoctorNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}