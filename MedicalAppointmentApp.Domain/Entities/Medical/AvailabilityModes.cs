﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    [Table("DoctorAvailability", Schema = "appointments")]
    public class AvailabilityModes : Base.BaseEntity
    {
        [Key]
        public Int16 AvailabilityModeID { get; set; }
        public string? AvailabilityMode { get; set;}

    }
}
