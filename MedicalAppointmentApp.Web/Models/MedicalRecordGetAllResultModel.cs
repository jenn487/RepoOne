using System.Collections.Generic;

namespace MedicalAppointmentApp.Web.Models
{
    public class MedicalRecordGetAllResultModel : BaseApiResponseModel
    {
        public List<MedicalRecordModel>? Data { get; set; }
    }

    public class MedicalRecordModel
    {
        public int MedicalRecordID { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Diagnosis { get; set; }
        public DateTime AppointmentDate { get; set; }
    }

    public class MedicalRecordSaveDto
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Diagnosis { get; set; }
        public DateTime AppointmentDate { get; set; }
    }

    public class MedicalRecordUpdateDto
    {
        public int MedicalRecordID { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Diagnosis { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
