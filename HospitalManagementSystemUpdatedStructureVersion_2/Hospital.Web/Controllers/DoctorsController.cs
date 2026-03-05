using Hospital.Web.Models;
using Hospital.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers;

public class DoctorsController : Controller
{
    private readonly DoctorApiService _service;

    public DoctorsController(DoctorApiService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var doctors = await _service.GetDoctors();
        return View(doctors);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(DoctorViewModel doctor)
    {
        await _service.AddDoctor(doctor);

        return RedirectToAction("Index");
    }
}