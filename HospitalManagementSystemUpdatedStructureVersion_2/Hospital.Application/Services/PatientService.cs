using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Domain.Exceptions;

namespace Hospital.Application.Services;

public class PatientService
{
    private readonly IPatientRepository _patientRepo;
    private readonly IDoctorRepository _doctorRepo;

    public PatientService(IPatientRepository patientRepo, IDoctorRepository doctorRepo)
    {
        _patientRepo = patientRepo;
        _doctorRepo = doctorRepo;
    }

    public IEnumerable<Patient> GetPatients()
    {
        var patients = _patientRepo.GetPatients();

        if (!patients.Any())
            throw new PatientNotFoundException("No patients found.");

        return patients;
    }

    public Patient FindPatient(string name)
    {
        var patient = _patientRepo.FindPatient(name);

        if (patient == null)
            throw new PatientNotFoundException($"Patient '{name}' not found.");

        return patient;
    }

    public void AddPatient(Patient patient)
    {
        var doctor = _doctorRepo.GetDoctors()
                                .FirstOrDefault(d => d.DoctorId == patient.DoctorId);

        if (doctor == null)
            throw new DoctorNotFoundException($"Doctor with ID {patient.DoctorId} not found.");

        _patientRepo.AddPatient(patient);
    }

    public void UpdatePatient(Patient patient)
    {
        var existingPatient = _patientRepo.GetPatients()
                                          .FirstOrDefault(p => p.PatientId == patient.PatientId);

        if (existingPatient == null)
            throw new PatientNotFoundException($"Patient with ID {patient.PatientId} not found.");

        var doctor = _doctorRepo.GetDoctors()
                                .FirstOrDefault(d => d.DoctorId == patient.DoctorId);

        if (doctor == null)
            throw new DoctorNotFoundException($"Doctor with ID {patient.DoctorId} not found.");

        _patientRepo.UpdatePatient(patient);
    }

    public void DeletePatient(int id)
    {
        var patient = _patientRepo.GetPatients().FirstOrDefault(p => p.PatientId == id);

        if (patient == null)
            throw new PatientNotFoundException($"Patient with ID {id} not found.");

        _patientRepo.DeletePatient(id);
    }
}