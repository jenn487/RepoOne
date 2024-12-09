using MedicalAppointmentApp.Aplication.Core; 

namespace MedicalAppointmentApp.Application.Responses.Medical.Specialties
{
    public class UpdateResponse : BaseResponse
    {
        public int SpecialtyID { get; set; }

       
        public string Message { get; set; } 
    }
}
