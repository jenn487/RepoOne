

namespace MedicalAppointmentApp.Web.Models
{
    public class SpecialtyGetAllResultModel : BaseApiResponseModel
    {
        public List<SpecialtyModel>? Data { get; set; }
    }

    public class SpecialtyModel
    {
        public int SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
    }

    public class SpecialtySaveDto
    {
        public string SpecialtyName { get; set; }
    }

    public class SpecialtyUpdateDto
    {
        public int SpecialtyID { get; set; }
        public string SpecialtyName { get; set; }
    }
}
