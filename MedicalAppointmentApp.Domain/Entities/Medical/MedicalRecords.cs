using System;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    public class MedicalRecords : Base.BaseEntity
    {
        public int RecordID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public string? Diagnosis { get; set; }
        public string? Treatment { get; set; }
        public DateTime DateOfVisit { get; set; }


    }
}
