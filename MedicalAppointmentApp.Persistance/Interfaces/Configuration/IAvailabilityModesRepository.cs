using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Domain.Repositories;

namespace MedicalAppointmentApp.Persistance.Interfaces.Configuration
{
    public interface IAvailabilityModesRepository : IBaseRepository<AvailabilityModes>
    {
        Task<AvailabilityModes> GetAvailabilityModesAsync();

    }
}
