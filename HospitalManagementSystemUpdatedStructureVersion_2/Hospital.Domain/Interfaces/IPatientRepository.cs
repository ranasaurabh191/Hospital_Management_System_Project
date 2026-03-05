using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces;

public interface IPatientRepository
{
    void AddPatient(Patient patient);
    void UpdatePatient(Patient patient);
    void DeletePatient(int id);
    IEnumerable<Patient> GetPatients();
    Patient? FindPatient(string name);
}