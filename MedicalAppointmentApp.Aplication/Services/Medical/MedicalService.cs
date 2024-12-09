using MedicalAppointmentApp.Aplication.Contracts;
using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Persistance.Interfaces.Configuration;

namespace MedicalAppointmentApp.Aplication.Services.Medical
{
    public class MedicalService : IMedicalRecordsService
    {
        private readonly IMedicalRecordRepository _repository;

        public MedicalService(IMedicalRecordRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MedicalRecords>> GetAllRecordsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<MedicalRecords?> GetRecordByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<MedicalRecords> CreateRecordAsync(MedicalRecords record)
        {
            return await _repository.AddAsync(record);
        }

        public async Task<MedicalRecords?> UpdateRecordAsync(int id, MedicalRecords record)
        {
            var existingRecord = await _repository.GetByIdAsync(id);
            if (existingRecord == null)
                return null;

            existingRecord.UpdateRecord(record.Diagnosis, record.Treatment);
            return await _repository.UpdateAsync(existingRecord);
        }

        public async Task<bool> DeleteRecordAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
