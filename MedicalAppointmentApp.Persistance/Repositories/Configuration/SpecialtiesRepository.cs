using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Domain.Result;
using MedicalAppointmentApp.Persistance.Base;
using MedicalAppointmentApp.Persistance.Context;
using MedicalAppointmentApp.Persistance.Interfaces.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


public class SpecialtiesRepository : BaseRepository<Specialties>, ISpecialtiesRepository
{
    private readonly MedicalAppointmentContext _context;
    private readonly ILogger<SpecialtiesRepository> _logger;

    public SpecialtiesRepository(MedicalAppointmentContext context, ILogger<SpecialtiesRepository> logger)
        : base(context)
    {
        _context = context;
        _logger = logger;
    }

    public async override Task<OperationResult> Save(Specialties entity)
    {
        OperationResult result = new();

        if (string.IsNullOrWhiteSpace(entity.SpecialtyName))
        {
            result.Success = false;
            result.Message = "El nombre de la especialidad es obligatorio.";
            return result;
        }

        if (await base.Exists(x => x.SpecialtyName == entity.SpecialtyName))
        {
            result.Success = false;
            result.Message = "Ya existe una especialidad con este nombre.";
            return result;
        }

        try
        {
            result = await base.Save(entity);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Error guardando la especialidad.";
            _logger.LogError(result.Message, ex);
        }

        return result;
    }

    public async Task<OperationResult> GetAll()
    {
        OperationResult result = new();

        try
        {
            result.Data = await _context.Specialties
                .Where(s => s.IsActive)
                .OrderBy(s => s.SpecialtyName)
                .ToListAsync();
            result.Success = true; 
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Error obteniendo las especialidades.";
            _logger.LogError(result.Message, ex);
        }

        return result;
    }
}
