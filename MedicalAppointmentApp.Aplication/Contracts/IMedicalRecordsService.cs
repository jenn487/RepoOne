using MedicalAppointmentApp.Domain.Entities.Medical;

namespace MedicalAppointmentApp.Aplication.Contracts
{
    public interface IMedicalRecordsService
    {
        Task<IEnumerable<MedicalRecords>> GetAllRecordsAsync();
        Task<MedicalRecords?> GetRecordByIdAsync(int id);
        Task<MedicalRecords> CreateRecordAsync(MedicalRecords record);
        Task<MedicalRecords?> UpdateRecordAsync(int id, MedicalRecords record);
        Task<bool> DeleteRecordAsync(int id);
        Task UpdateAsync(MedicalAppointmentApp.Web.Models.MedicalRecordUpdateDto medicalRecordUpdate);
    }
}
