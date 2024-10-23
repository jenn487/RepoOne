using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentApp.Domain.Entities.System
{
    [Table("Roles", Schema = "system")]
    public class Roles : Base.BaseEntity
    {
        [Key]
        public int RoleID { get; set; }
        public string? RoleName { get; set; }

    }
}
