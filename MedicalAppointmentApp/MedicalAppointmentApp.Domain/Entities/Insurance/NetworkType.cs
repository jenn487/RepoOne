using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentApp.Domain.Entities.Insurance
{
    [Table("NetworkType", Schema = "insurance")]
    public class NetworkType : Base.BaseEntity
    {
        [Key]
        public int NetworkTypeId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}