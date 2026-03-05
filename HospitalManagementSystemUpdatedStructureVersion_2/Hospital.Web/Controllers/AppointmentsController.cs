using Hospital.Web.Models;
using Hospital.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppointmentApiService _service;

        public AppointmentsController(AppointmentApiService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _service.GetAppointments();
            return View(appointments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentViewModel appointment)
        {
            await _service.AddAppointment(appointment);

            return RedirectToAction("Index");
        }
    }
}