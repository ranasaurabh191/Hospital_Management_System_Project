using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces;
using Hospital.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Repositories;

public class DoctorRepositoryEF : IDoctorRepository
{
    private readonly HospitalDbContext _context;

    public DoctorRepositoryEF(HospitalDbContext context)
    {
        _context = context;
    }

    public void AddDoctor(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
    }
    public Doctor? FindDoctor(string name)
    {
        return _context.Doctors.FirstOrDefault(d => d.Name == name);
    }
    public IEnumerable<Doctor> GetDoctors()
    {
        return _context.Doctors
                       .Include(d => d.Patients)
                       .Include(d => d.Appointments)
                       .ToList();
    }
}