using Microsoft.AspNetCore.Mvc;
using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Domain.Repositories;
using MedicalAppointmentApp.Domain.Result;

namespace MedicalAppointmentApp.Medical.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvailabilityModesController : ControllerBase
    {
        private readonly IAvailabilityModesRepository _repository;

        public AvailabilityModesController(IAvailabilityModesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<OperationResult>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _repository.GetAll(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OperationResult>> Create([FromBody] AvailabilityModes mode)
        {
            var result = await _repository.Save(mode);
            return CreatedAtAction(nameof(GetAll), result);
        }
    }
}
