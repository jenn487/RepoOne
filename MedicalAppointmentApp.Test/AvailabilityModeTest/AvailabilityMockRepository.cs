using MedicalAppointmentApp.Domain.Entities.Configuration; 
using MedicalAppointmentApp.Domain.Result; 
using MedicalAppointmentApp.Persistance.Interfaces.Configuration; 
using MedicalAppointmentApp.Test.Context; 
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Test.AvailabilityModeTest
{
    public class AvailabilityModeMockRepository : IAvailabilityModeRepository 
        private readonly MedicalAppointmentMockContext context;

        public AvailabilityModeMockRepository(MedicalAppointmentMockContext context)
        {
            this.context = context;
        }

        public Task<bool> Exists(Expression<Func<AvailabilityMode, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAll(Expression<Func<AvailabilityMode, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetAvailabilityModeById(int availabilityModeId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult> Remove(AvailabilityMode entity)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult> Save(AvailabilityMode entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                if (entity == null)
                {
                    result.Success = false;
                    result.Message = "La disponibilidad es requerida.";
                    return result;
                }

                e

                await this.context.AddAsync(entity);
                await this.context.SaveChangesAsync();
                result.Success = true; 
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando la disponibilidad.";
                result.Success = false;
            }

            return result;
        }

        public Task<OperationResult> Update(AvailabilityMode entity)
        {
            throw new NotImplementedException();
        }
    }
}
