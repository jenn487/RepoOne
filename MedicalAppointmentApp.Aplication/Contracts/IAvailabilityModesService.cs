using MedicalAppointmentApp.Aplication.Base;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Application.Contracts
{
    public interface IAvailabilityModesService
    {
        Task<NotificationsResponse> GetAll();
        Task<NotificationsResponse> GetById(int id);
        Task<NotificationsResponse> SaveAsync(AvailabilityModeSaveDto availabilityModeSave);
        Task<NotificationsResponse> UpdateAsync(AvailabilityModeUpdateDto availabilityModeUpdate);
    }

    public class AvailabilityModeUpdateDto
    {
    }

    public class NotificationsUpdateDto
    {
        
    }

    public class NotificationsResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; } 
    }

    public class NotificationsSaveDto
    {
        
    }

    public class AvailabilityModeSaveDto
    {
        
    }
}
