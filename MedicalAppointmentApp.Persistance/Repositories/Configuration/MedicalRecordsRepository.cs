using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Persistance.Context;
using MedicalAppointmentApp.Persistance.Interfaces.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentApp.Persistance.Repositories.Configuration
{
    public class MedicalRecordsRepository : IMedicalRecordRepository
    {
        private readonly MedicalAppointmentContext _context;

        public MedicalRecordsRepository(MedicalAppointmentContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicalRecords>> GetAllAsync()
        {
            return await _context.MedicalRecords.ToListAsync();
        }

        public async Task<MedicalRecords?> GetByIdAsync(int id)
        {
            return await _context.MedicalRecords.FindAsync(id);
        }

        public async Task<MedicalRecords> AddAsync(MedicalRecords record)
        {
            _context.MedicalRecords.Add(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<MedicalRecords> UpdateAsync(MedicalRecords record)
        {
            _context.MedicalRecords.Update(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var record = await GetByIdAsync(id);
            if (record == null) return false;
            _context.MedicalRecords.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
