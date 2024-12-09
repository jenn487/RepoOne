using System.Collections.Generic;

namespace MedicalAppointmentApp.Web.Models
{
    public class AvailabilityModeGetAllResultModel : BaseApiResponseModel
    {
        public List<AvailabilityModeModel>? Data { get; set; }
    }

    public class AvailabilityModeModel
    {
        public int AvailabilityModeID { get; set; }
        public string ModeName { get; set; }
    }

    public class AvailabilityModeSaveDto
    {
        public string ModeName { get; set; }
    }

    public class AvailabilityModeUpdateDto
    {
        public int AvailabilityModeID { get; set; }
        public string ModeName { get; set; }
    }
}
