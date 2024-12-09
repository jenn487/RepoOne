using MedicalAppointmentApp.Web.Models;
using MedicalAppointmentApp.Web.Service.Base;
using Microsoft.Extensions.Logging;

namespace MedicalAppointmentApp.Web.Service
{
    public class AvailabilityModeApiClientService : IAvailabilityModeApiClientService
    {
        private readonly IHttpService _httpService;
        private readonly ILogger<AvailabilityModeApiClientService> _logger;

        public AvailabilityModeApiClientService(IHttpService httpService, ILogger<AvailabilityModeApiClientService> logger)
        {
            _httpService = httpService;
            _logger = logger;
        }

        public async Task<AvailabilityModeGetAllResultModel> GetAvailabilityModes()
        {
            AvailabilityModeGetAllResultModel resultModel = new AvailabilityModeGetAllResultModel();
            try
            {
                resultModel = await _httpService.GetAsync<AvailabilityModeGetAllResultModel>("AvailabilityModes/GetAvailabilityModes");
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Message = "Error obteniendo los modos de disponibilidad";
                _logger.LogError($"{resultModel.Message} {ex}");
            }
            return resultModel;
        }
    }
}
