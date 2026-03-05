using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;

namespace Hospital.Application.Services;

public class AppointmentService
{
    private readonly IAppointmentRepository _repo;

    public AppointmentService(IAppointmentRepository repo)
    {
        _repo = repo;
    }

    public void AddAppointment(Appointment appointment)
    {
        _repo.AddAppointment(appointment);
    }

    public IEnumerable<Appointment> GetAppointments()
    {
        var appointments = _repo.GetAppointments();

        if (!appointments.Any())
            throw new Exception("No appointments found.");

        return appointments;
    }
}