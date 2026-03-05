using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Domain.Exceptions;

namespace Hospital.Application.Services;

public class PatientService
{
    private readonly IPatientRepository _repo;

    public PatientService(IPatientRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<Patient> GetPatients()
    {
        var patients = _repo.GetPatients();

        if (!patients.Any())
            throw new PatientNotFoundException("No patients found.");

        return patients;
    }

    public Patient FindPatient(string name)
    {
        var patient = _repo.FindPatient(name);

        if (patient == null)
            throw new PatientNotFoundException($"Patient '{name}' not found.");

        return patient;
    }

    public void AddPatient(Patient patient)
    {
        _repo.AddPatient(patient);
    }

    public void UpdatePatient(Patient patient)
    {
        var existingPatient = _repo.GetPatients().FirstOrDefault(p => p.PatientId == patient.PatientId);

        if (existingPatient == null)
            throw new PatientNotFoundException($"Patient with ID {patient.PatientId} not found.");

        _repo.UpdatePatient(patient);
    }

    public void DeletePatient(int id)
    {
        var patient = _repo.GetPatients().FirstOrDefault(p => p.PatientId == id);

        if (patient == null)
            throw new PatientNotFoundException($"Patient with ID {id} not found.");

        _repo.DeletePatient(id);
    }
}