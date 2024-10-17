using System;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    public class Specialties
    {
        public short SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

    }
}
