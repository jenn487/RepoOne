using MedicalAppointmentApp.Infraestructure.Models;
using MedicalAppointmentApp.Infraestructure.Results;

namespace MedicalAppointmentApp.Infraestructure.Interfaces
{
    public interface IMedicalService
    {
        Task<NotificationResult> SendEmailAsync(EmailModel emailModel);
        Task<NotificationResult> SendSmsAsync(SmsModel smsModel);
        Task<NotificationResult> SendPushNotification(PushModel pushModel);
    }
}