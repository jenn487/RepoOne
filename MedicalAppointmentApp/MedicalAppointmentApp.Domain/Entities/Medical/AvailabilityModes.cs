using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    [Table("DoctorAvailability", Schema = "appointments")]
    public class AvailabilityModes : Base.BaseEntity
    {
        [Key]
        public short AvailabilityModeID { get; set; }
        public string? AvailabilityMode { get; set;}

    }
}
