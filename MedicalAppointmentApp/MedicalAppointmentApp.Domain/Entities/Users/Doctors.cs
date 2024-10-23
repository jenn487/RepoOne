using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalAppointmentApp.Domain.Entities.Users
{
    [Table("Doctors", Schema = "users")]
    public class Doctors : Base.BaseEntity
    {
        [Key]
        public int DoctorsID { get; set; }
        public short SpecialtyID { get; set; }
        public string? LicenseNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string? Education { get; set; }
        public string? Bio { get; set; }
        public decimal? ConsultationFree { get; set; }
        public string? ClinicAddress { get; set; }
        public short? AvailabilityModeld  { get; set; }
        public DateOnly LicenseExpirationDate { get; set; }

        public void UpdateProfile(string phoneNumber, string education, decimal consultationFee)
        {
            PhoneNumber = phoneNumber;
            Education = education;
            ConsultationFree = consultationFee;
        }
    }
}
