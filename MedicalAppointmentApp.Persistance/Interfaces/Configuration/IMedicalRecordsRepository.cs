using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Domain.Repositories;
using MedicalAppointmentApp.Domain.Result;

namespace MedicalAppointmentApp.Persistance.Interfaces.Configuration
{
    public class IMedicalRecordRepository : IBaseRepository<MedicalRecords>
    {
        public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsActive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Task<OperationResult> Exists(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Remove(MedicalRecords entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Save(MedicalRecords entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Update(MedicalRecords entity)
        {
            throw new NotImplementedException();
        }
    }
}
