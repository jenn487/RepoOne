using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    [Table("MedicalRecords", Schema = "medical")]
    public class MedicalRecords : Base.BaseEntity
    {
        [Key]
        public int RecordID { get; set; }

        [Required]
        public int PatientID { get; set; }

        [Required]
        public int DoctorID { get; set; }

        [Required]
        [StringLength(500)]
        public string Diagnosis { get; set; }

        [Required]
        [StringLength(500)]
        public string Treatment { get; set; }

        [Required]
        public DateTime DateOfVisit { get; set; }
        public int SpecialtyID { get; set; }

        // actualiza la informacion medica del paciente
        public void UpdateRecord(string diagnosis, string treatment)
        {
            if (string.IsNullOrWhiteSpace(diagnosis))
                throw new ArgumentException("Diagnosis cannot be empty", nameof(diagnosis));
            if (string.IsNullOrWhiteSpace(treatment))
                throw new ArgumentException("Treatment cannot be empty", nameof(treatment));
            Diagnosis = diagnosis;
            Treatment = treatment;
        }
    }
}
