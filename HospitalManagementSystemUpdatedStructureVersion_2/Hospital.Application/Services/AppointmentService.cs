using Hospital.Domain.Entities;
using Hospital.Domain.Exceptions;
using Hospital.Domain.Interfaces;

namespace Hospital.Application.Services;

public class AppointmentService
{
    private readonly IAppointmentRepository _appointmentRepo;
    private readonly IDoctorRepository _doctorRepo;
    private readonly IPatientRepository _patientRepo;

    public AppointmentService(
        IAppointmentRepository appointmentRepo,
        IDoctorRepository doctorRepo,
        IPatientRepository patientRepo)
    {
        _appointmentRepo = appointmentRepo;
        _doctorRepo = doctorRepo;
        _patientRepo = patientRepo;
    }

    public void AddAppointment(Appointment appointment)
    {
        var doctor = _doctorRepo.GetDoctors()
                                .FirstOrDefault(d => d.DoctorId == appointment.DoctorId);

        if (doctor == null)
            throw new DoctorNotFoundException($"Doctor with ID {appointment.DoctorId} not found.");

        var patient = _patientRepo.GetPatients()
                                  .FirstOrDefault(p => p.PatientId == appointment.PatientId);

        if (patient == null)
            throw new PatientNotFoundException($"Patient with ID {appointment.PatientId} not found.");

        _appointmentRepo.AddAppointment(appointment);
    }

    public IEnumerable<Appointment> GetAppointments()
    {
        var appointments = _appointmentRepo.GetAppointments();

        if (!appointments.Any())
            throw new Exception("No appointments found.");

        return appointments;
    }
}