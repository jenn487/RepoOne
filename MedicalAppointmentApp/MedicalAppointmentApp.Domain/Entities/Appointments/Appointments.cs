using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentApp.Domain.Entities.Appointments
{
    //"public sealed class" para cellar la clase y no pueda ser heredada
    [Table("Appointments", Schema = "appointments")]
    public class Appointments               
    {
        [Key]
        public int AppointmentID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int StatusID { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdatedAt { get; set; }   //El "?" significa que UpdateAt puede ser null 

    }
}
