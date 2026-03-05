using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Domain.Exceptions;

namespace Hospital.Application.Services;

public class DoctorService
{
    private readonly IDoctorRepository _repo;

    public DoctorService(IDoctorRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<Doctor> GetDoctors()
    {
        var doctors = _repo.GetDoctors();

        if (!doctors.Any())
            throw new DoctorNotFoundException("No doctors found.");

        return doctors;
    }

    public Doctor FindDoctor(string name)
    {
        var doctor = _repo.FindDoctor(name);

        if (doctor == null)
            throw new DoctorNotFoundException($"Doctor '{name}' not found.");

        return doctor;
    }
    public Doctor GetDoctorById(int id)
    {
        var doctor = _repo.GetDoctors().FirstOrDefault(d => d.DoctorId == id);

        if (doctor == null)
            throw new DoctorNotFoundException($"Doctor with ID {id} not found.");

        return doctor;
    }

    public void AddDoctor(Doctor doctor)
    {
        _repo.AddDoctor(doctor);
    }
}