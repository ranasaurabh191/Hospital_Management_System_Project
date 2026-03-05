using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces;

public interface IAppointmentRepository
{
    void AddAppointment(Appointment appointment);
    IEnumerable<Appointment> GetAppointments();
}