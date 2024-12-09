using MedicalAppointmentApp.Domain.Entities.Configuration; 
using MedicalAppointmentApp.Domain.Result; 
using MedicalAppointmentApp.Persistance.Interfaces.Configuration; 
using MedicalAppointmentApp.Persistance.Repositories.Configuration; 
using MedicalAppointmentApp.Test.AvailabilityModeTest; 
using MedicalAppointmentApp.Test.Context; 
using Microsoft.Extensions.Logging;
using Moq;
using Xunit; 

namespace MedicalAppointmentApp.Test
{
    public class UnitTestAvailabilityMode
    {
        private readonly IAvailabilityModeRepository _availabilityModeRepository;

        public UnitTestAvailabilityMode()
        {
            var loggerMock = new Mock<ILogger<AvailabilityModeRepository>>(); 
            var medicalAppointmentMockContext = new Mock<MedicalAppointmentMockContext>(); 
            _availabilityModeRepository = new AvailabilityModeRepository(medicalAppointmentMockContext.Object, loggerMock.Object); 
        }

        [Fact]
        public async void AddAvailabilityMode_NullAvailabilityMode_ReturnsFailure()
        {
            
            AvailabilityMode availabilityMode = null; 

            
            var result = await _availabilityModeRepository.Save(availabilityMode);
            var message = "La disponibilidad es requerida."; 

            
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}
