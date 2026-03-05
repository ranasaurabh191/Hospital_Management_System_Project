using System.ComponentModel.DataAnnotations;

namespace Hospital.Web.Models
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PatientId { get; set; }
    }
}