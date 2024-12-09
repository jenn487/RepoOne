using MedicalAppointmentApp.Web.Models;
using MedicalAppointmentApp.Web.Service.Base;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Design;

namespace MedicalAppointmentApp.Web.Service
{
    public class MedicalRecordApiClientService : IMedicalRecordApiClientService
    {
        private readonly IHttpService _httpService;
        private readonly ILogger<MedicalRecordApiClientService> _logger;

        public MedicalRecordApiClientService(IHttpService httpService, ILogger<MedicalRecordApiClientService> logger)
        {
            _httpService = httpService;
            _logger = logger;
        }

        public async Task<MedicalRecordGetAllResultModel> GetMedicalRecords()
        {
            MedicalRecordGetAllResultModel resultModel = new MedicalRecordGetAllResultModel();
            try
            {
                resultModel = await _httpService.GetAsync<MedicalRecordGetAllResultModel>("MedicalRecords/GetMedicalRecords");
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Message = "Error obteniendo los registros médicos";
                _logger.LogError($"{resultModel.Message} {ex}");
            }
            return resultModel;
        }
    }
}
