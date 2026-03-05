using System.ComponentModel.DataAnnotations;

namespace Hospital.Web.Models;

public class DoctorViewModel
{
    public int DoctorId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Specialization { get; set; } = string.Empty;

    [Required]
    public decimal ConsultationFee { get; set; }
}