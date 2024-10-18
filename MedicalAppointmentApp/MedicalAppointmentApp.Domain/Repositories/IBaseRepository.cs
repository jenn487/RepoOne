using MedicalAppointmentApp.Domain.Result;

namespace MedicalAppointmentApp.Domain.Repositories
{
        // "Task" puede realizar operaciones de manera asincrona

        public interface IBaseRepository<TEntity> where TEntity : class
    {
            Task<OperationResult> Save(TEntity entity);
            Task<OperationResult> Update(TEntity entity);
            Task<OperationResult> Remove(TEntity entity);
            Task<OperationResult> GetAll(int pageNumber, int pageSize);
            Task<OperationResult> GetById(int Id);
            Task<OperationResult> Exists(int Id);

            // Estas son las propiedades comunes para mayoria de entidades
            DateTime CreatedAt { get; set; }
            DateTime? UpdatedAt { get; set; }
            bool IsActive { get; set; }
        }
}
