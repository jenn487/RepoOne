using System.Linq.Expressions;

namespace MedicalAppointmentApp.Domain.Repositories
{
    // "Task" puede realizar operaciones de manera asincrona

    public interface IBaseRepository<TEntity> where TEntity : class
        {
            Task Save(TEntity entity);
            Task Update(TEntity entity);
            Task Remove(TEntity entity);
            Task<TEntity> GetAll();
            Task GetEntityBy(Type Id);
            Task<bool> Exists(Expression<Func<TEntity, bool>> filter);

            // Estas son las propiedades comunes para mayoria de entidades
            DateTime CreatedAt { get; set; }
            DateTime? UpdatedAt { get; set; }
            bool IsActive { get; set; }
        }
}
