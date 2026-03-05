using Hospital.Application.Services;
using Hospital.Domain.Entities;
using Hospital.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientsController : ControllerBase
{
    private readonly PatientService _service;

    public PatientsController(PatientService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var patients = _service.GetPatients();
            return Ok(patients);
        }
        catch (PatientNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult Add(Patient patient)
    {
        _service.AddPatient(patient);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(Patient patient)
    {
        try
        {
            _service.UpdatePatient(patient);
            return Ok("Patient updated successfully.");
        }
        catch (PatientNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _service.DeletePatient(id);
            return Ok("Patient deleted successfully.");
        }
        catch (PatientNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpGet("search/{name}")]
    public IActionResult Find(string name)
    {
        try
        {
            var patient = _service.FindPatient(name);
            return Ok(patient);
        }
        catch (PatientNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}