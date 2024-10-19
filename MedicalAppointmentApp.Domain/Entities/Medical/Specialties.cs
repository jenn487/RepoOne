using System;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    public class Specialties : Base.BaseEntity
    {
        public short SpecialtyID { get; set; }
        public string? SpecialtyName { get; set; }

    }
}
