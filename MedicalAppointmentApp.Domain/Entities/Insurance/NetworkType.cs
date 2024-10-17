using System;

namespace MedicalAppointmentApp.Domain.Entities.Insurance
{
    public class NetworkType
    {
        public int NetworkTypeId {  get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
