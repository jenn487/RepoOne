using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Domain.Result;
using MedicalAppointmentApp.Persistance.Base;
using MedicalAppointmentApp.Persistance.Context;
using MedicalAppointmentApp.Persistance.Interfaces.Configuration;
using Microsoft.Extensions.Logging;

public class AvailabilityModesRepository : BaseRepository<AvailabilityModes>, IAvailabilityModesRepository
{
    private readonly MedicalAppointmentContext _context;
    private readonly ILogger<AvailabilityModesRepository> _logger;

    public AvailabilityModesRepository(MedicalAppointmentContext context, ILogger<AvailabilityModesRepository> logger)
        : base(context)
    {
        _context = context;
        _logger = logger;
    }

    public async override Task<OperationResult> Save(AvailabilityModes entity)
    {
        OperationResult result = new();

        if (string.IsNullOrWhiteSpace(entity.AvailabilityMode))
        {
            result.Success = false;
            result.Message = "El nombre del modo de disponibilidad es obligatorio.";
            return result;
        }

        if (await base.Exists(x => x.AvailabilityMode == entity.AvailabilityMode))
        {
            result.Success = false;
            result.Message = "Ya existe un modo de disponibilidad con este nombre.";
            return result;
        }

        try
        {
            result = await base.Save(entity);
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Error guardando el modo de disponibilidad.";
            _logger.LogError(result.Message, ex.ToString());
        }

        return result;
    }

    public async override Task<OperationResult> Remove(AvailabilityModes entity)
    {
        OperationResult result = new();

        if (entity.AvailabilityModeID <= 0)
        {
            result.Success = false;
            result.Message = "El ID del modo de disponibilidad no es válido.";
            return result;
        }

        try
        {
            var mode = await _context.AvailabilityModes.FindAsync(entity.AvailabilityModeID);
            if (mode != null)
            {
                mode.IsActive = false;
                await base.Update(mode);
            }
        }
        catch (Exception ex)
        {
            result.Success = false;
            result.Message = "Error eliminando el modo de disponibilidad.";
            _logger.LogError(result.Message, ex.ToString());
        }

        return result;
    }

    public Task<AvailabilityModes> GetAvailabilityModesAsync()
    {
        throw new NotImplementedException();
    }
}
