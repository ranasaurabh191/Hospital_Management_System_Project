using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces;

public interface IDoctorRepository
{
    void AddDoctor(Doctor doctor);
    Doctor? FindDoctor(string name);
    IEnumerable<Doctor> GetDoctors();
}