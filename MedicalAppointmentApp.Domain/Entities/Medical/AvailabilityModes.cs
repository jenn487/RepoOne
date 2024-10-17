﻿using System;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    public class AvailabilityModes
    {
        public short SAvailabilityModeID { get; set; }
        public string AvailabilityMode { get; set;}
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
