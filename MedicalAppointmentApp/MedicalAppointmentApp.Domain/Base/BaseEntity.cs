﻿
namespace MedicalAppointmentApp.Domain.Base
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        protected BaseEntity()
        {
            CreatedAt = DateTime.MinValue;
        }
        public void UpdateTimes()
        {
            UpdatedAt = DateTime.MinValue;
        }

    }
}
