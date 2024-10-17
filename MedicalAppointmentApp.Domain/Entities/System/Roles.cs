using System;

namespace MedicalAppointmentApp.Domain.Entities.System
{
    public class Roles : Base.BaseEntity
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

    }
}
