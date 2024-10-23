using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentApp.Domain.Entities.Appointments
{
    [Table("Appointments", Schema = "appointments")]
    public sealed class Appointments // "public sealed class" para evitar la herencia
    {
        [Key]
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int StatusID { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }   // El "?" significa que UpdatedAt puede ser null

        // Para manejar la reprogramación y confirmacion o cancelacion de citas
        public void Reschedule(DateTime newDate)
        {
            AppointmentDate = newDate;
            UpdatedAt = DateTime.Now;
        }

        public void ConfirmAppointment()
        {
            StatusID = 3; 
            UpdatedAt = DateTime.Now;
        }

        public void RejectAppointment()
        {
            StatusID = 2; 
            UpdatedAt = DateTime.Now;
        }
    }
}
