using System.ComponentModel.DataAnnotations;


namespace MedicalAppointmentApp.Domain.Entities.System
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string? StatusName { get; set; }
    }
}
