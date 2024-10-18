using System;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    public class AvailabilityModes : Base.BaseEntity
    {
        public short SAvailabilityModeID { get; set; }
        public string AvailabilityMode { get; set;}

    }
}
