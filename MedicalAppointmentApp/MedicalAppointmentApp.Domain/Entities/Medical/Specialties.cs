using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    [Table("Specialties", Schema = "medical")]
    public class Specialties : Base.BaseEntity
    {
        [Key]
        public int SpecialtyID { get; set; }
        public string? SpecialtyName { get; set; }

    }
}
