using System;

namespace MedicalAppointmentApp.Domain.Entities.Users
{
    public class Patients : Base.BaseEntity
    {
        public int PatienteID { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string BloodType { get; set; }
        public string Allergies { get; set; }
        public int InsuranceProviderID { get; set; }


}
}
