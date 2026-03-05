using Hospital.Web.Models;
using Hospital.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers;

public class PatientsController : Controller
{
    private readonly PatientApiService _service;

    public PatientsController(PatientApiService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var patients = await _service.GetPatients();
        return View(patients);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PatientViewModel patient)
    {
        await _service.AddPatient(patient);
        return RedirectToAction("Index");
    }
}