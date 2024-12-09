using Microsoft.AspNetCore.Mvc;
using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Domain.Repositories;
using MedicalAppointmentApp.Domain.Result;

namespace MedicalAppointmentApp.Medical.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalController : ControllerBase
    {
        private readonly IMedicalRecordRepository _repository;

        public MedicalController(IMedicalRecordRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<OperationResult>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _repository.GetAll(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OperationResult>> GetById(int id)
        {
            var result = await _repository.GetEntityById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OperationResult>> Create([FromBody] MedicalRecords record)
        {
            var result = await _repository.Save(record);
            return CreatedAtAction(nameof(GetById), new { id = record.RecordID }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OperationResult>> Update(int id, [FromBody] MedicalRecords record)
        {
            if (id != record.RecordID)
                return BadRequest();

            var result = await _repository.Update(record);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationResult>> Delete(int id)
        {
            var record = await _repository.GetEntityById(id);
            if (record.Data == null)
                return NotFound();

            var result = await _repository.Remove((MedicalRecords)record.Data);
            return Ok(result);
        }
    }
}
