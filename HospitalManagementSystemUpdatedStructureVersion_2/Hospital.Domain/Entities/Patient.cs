namespace Hospital.Domain.Entities;

public class Patient
{
    public int PatientId { get; set; }
    public string Name { get; set; } =  string.Empty;
    public string Condition { get; set; } = string.Empty;
    public int DoctorId { get; set; }
}