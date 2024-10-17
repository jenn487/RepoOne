﻿using System;

namespace MedicalAppointmentApp.Domain.Entities.System
{
    public class Notifications
    {
        public int NotificationID {  get; set; }
        public int UserID { get; set; }
        public string Message { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
