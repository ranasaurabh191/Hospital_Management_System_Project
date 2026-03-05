using System.ComponentModel.DataAnnotations;

namespace Hospital.Web.Models
{
    public class PatientViewModel
    {
        public int PatientId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Condition { get; set; } = string.Empty;

        [Required]
        public int DoctorId { get; set; }
    }
}