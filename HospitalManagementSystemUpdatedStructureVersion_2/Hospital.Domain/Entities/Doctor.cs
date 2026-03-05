namespace Hospital.Domain.Entities;

public class Doctor
{
    public int DoctorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialization { get; set; } = string.Empty;
    public decimal ConsultationFee { get; set; }

    public List<Patient> Patients { get; set; } = new();
    public List<Appointment> Appointments { get; set; } = new();
}