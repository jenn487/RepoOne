using System;

namespace MedicalAppointmentApp.Domain.Entities.Users
{
    public class Doctors : Base.BaseEntity
    {
        public int DoctorsID { get; set; }
        public short SpecialtyID { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string Education { get; set; }
        public string? Bio { get; set; }
        public decimal? ConsultationFree { get; set; }
        public string? ClinicAddress { get; set; }
        public short? AvailabilityModeld  { get; set; }
        public DateOnly LicenseExpirationDate { get; set; }


    }
}
