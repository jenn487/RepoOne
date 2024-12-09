using MedicalAppointmentApp.Infraestructure.Models;
using MedicalAppointmentApp.Infraestructure.Results;
using System.Net.Mail;
using System.Net;
using MedicalAppointmentApp.Infraestructure.Interfaces;

namespace MedicalAppointmentApp.Infraestructure.Services
{
    public class EmailSendService : IMedicalService
    {
        public async Task<NotificationResult> SendEmailAsync(EmailModel emailModel)
        {
            NotificationResult result = new NotificationResult();

            try
            {
                using (var client = new SmtpClient())
                {
                    client.Host = "";
                    client.Port = 0;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("user", "pwd");

                    var message = new MailMessage(emailModel.From!, emailModel.To!);
                    message.Body = emailModel.Body;
                    message.IsBodyHtml = true;
                    message.Subject = emailModel.Subject;

                    await client.SendMailAsync(message);

                }
            }
            catch (Exception ex)
            {

                result.Message = $"Error realizando la notificación {ex.Message}";
            }

            return result;
        }

        public Task<NotificationResult> SendPushNotification(PushModel pushModel)
        {
            throw new NotImplementedException();
        }

        public Task<NotificationResult> SendSmsAsync(SmsModel smsModel)
        {
            throw new NotImplementedException();
        }
    }
}