using MedicalAppointmentApp.Web.Models;
using System.ComponentModel.Design;

namespace MedicalAppointmentApp.Web.Service
{
    public class SpecialtyApiClientService : ISpecialtyApiClientService
    {
        private readonly IHelpService _httpService;
        private readonly ILogger<SpecialtyApiClientService> _logger;

        public SpecialtyApiClientService(IHelpService httpService, ILogger<SpecialtyApiClientService> logger)
        {
            _httpService = httpService;
            _logger = logger;
        }

        public async Task<SpecialtyGetAllResultModel> GetSpecialties()
        {
            SpecialtyGetAllResultModel specialtyGetAllResultModel = new SpecialtyGetAllResultModel();
            try
            {
                specialtyGetAllResultModel = await _httpService.GetAsync<SpecialtyGetAllResultModel>("Specialties/GetSpecialties");
            }
            catch (Exception ex)
            {
                specialtyGetAllResultModel.IsSuccess = false;
                specialtyGetAllResultModel.Message = "Error obteniendo las especialidades";
                _logger.LogError($"{specialtyGetAllResultModel.Message} {ex.ToString()}");
            }
            return specialtyGetAllResultModel;
        }
    }
}
