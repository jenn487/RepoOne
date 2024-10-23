using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    [Table("MedicalRecords", Schema = "medical")]
    public class MedicalRecords : Base.BaseEntity
    {
        [Key]
        public int RecordID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string? Diagnosis { get; set; }
        public string? Treatment { get; set; }
        public DateTime DateOfVisit { get; set; }

        // actualiza la informacion medica del paciente
        public void UpdateRecord(string diagnosis, string treatment)
        {
            Diagnosis = diagnosis;
            Treatment = treatment;
        }
    }
}
