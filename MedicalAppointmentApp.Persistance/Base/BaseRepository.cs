using MedicalAppointmentApp.Domain.Repositories;
using MedicalAppointmentApp.Domain.Result;
using MedicalAppointmentApp.Persistance.Context;
using MedicalAppointmentApp.Persistance.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedicalAppointmentApp.Persistance.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly MedicalAppointmentContext _context;
        protected DbSet<TEntity> Entities;

        public BaseRepository(MedicalAppointmentContext context)
        {
            _context = context;
            Entities = _context.Set<TEntity>();
        }

        public MedicalAppointmentContext Context => _context;
        DateTime IBaseRepository<TEntity>.CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime? IBaseRepository<TEntity>.UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool IBaseRepository<TEntity>.IsActive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await Entities.AnyAsync(filter);
        }

        public virtual async Task<OperationResult> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var result = new OperationResult();
            try
            {
                var data = await Entities
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
                result.Data = data;
                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new MedicalDataException("Error obteniendo datos.", ex);
            }
            return result;
        }

        public virtual async Task<OperationResult> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            var result = new OperationResult();
            try
            {
                result.Data = await Entities.Where(filter).ToListAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new MedicalDataException("Error al filtrar datos.", ex);
            }
            return result;
        }

        public virtual async Task<OperationResult> GetEntityById(int id)
        {
            var result = new OperationResult();
            try
            {
                result.Data = await Entities.FindAsync(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new MedicalDataException("Error obteniendo entidad por ID.", ex);
            }
            return result;
        }

        public virtual async Task<OperationResult> Remove(TEntity entity)
        {
            var result = new OperationResult();
            try
            {
                Entities.Remove(entity);
                await _context.SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new MedicalDataException("Error eliminando entidad.", ex);
            }
            return result;
        }

        public virtual async Task<OperationResult> Save(TEntity entity)
        {
            var result = new OperationResult();
            try
            {
                Entities.Add(entity);
                await _context.SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new MedicalDataException("Error guardando entidad.", ex);
            }
            return result;
        }

        public virtual async Task<OperationResult> Update(TEntity entity)
        {
            var result = new OperationResult();
            try
            {
                Entities.Update(entity);
                await _context.SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new MedicalDataException("Error actualizando entidad.", ex);
            }
            return result;
        }

        Task<OperationResult> IBaseRepository<TEntity>.Exists(int Id)
        {
            throw new NotImplementedException();
        }

        Task<OperationResult> IBaseRepository<TEntity>.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
