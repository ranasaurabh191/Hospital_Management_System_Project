using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Infrastructure.Data;

namespace Hospital.Infrastructure.Repositories;

public class AppointmentRepositoryEF : IAppointmentRepository
{
    private readonly HospitalDbContext _context;

    public AppointmentRepositoryEF(HospitalDbContext context)
    {
        _context = context;
    }

    public void AddAppointment(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        _context.SaveChanges();
    }

    public IEnumerable<Appointment> GetAppointments()
    {
        return _context.Appointments.ToList();
    }
}