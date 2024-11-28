using MedicalAppointments.Persistance.Interfaces.Appointment;
using Microsoft.AspNetCore.Mvc;
using MedicalAppointments.Persistance.Models.Appointments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalAppointments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : ControllerBase
    {
        private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;

        public DoctorAvailabilityController(IDoctorAvailabilityRepository doctorAvailabilityRepository)
        {
            _doctorAvailabilityRepository = doctorAvailabilityRepository;
        }

        [HttpGet("GetAvailableDoctors")]
        public async Task<ActionResult<IEnumerable<DoctorAvailabilityDoctorSpecialtyUsersModel>>> GetAvailableDoctors()
        {
            var result = await _doctorAvailabilityRepository.GetAvailableDoctors();

            if (result == null || result.Count == 0)
            {
                return NotFound(new { Message = "No doctors available." });
            }

            return Ok(result);
        }

        [HttpGet("GetDoctorAvailability/{doctorId}")]
        public async Task<ActionResult<DoctorAvailabilityDoctorSpecialtyUsersModel>> GetDoctorAvailability(int doctorId)
        {
            var result = await _doctorAvailabilityRepository.GetDoctorAvailability(doctorId);

            if (result == null)
            {
                return NotFound(new { Message = "Doctor not found or availability not set." });
            }

            return Ok(result);
        }

        [HttpPost("CreateDoctorAvailability")]
        public async Task<ActionResult<DoctorAvailabilityDoctorSpecialtyUsersModel>> CreateDoctorAvailability([FromBody] DoctorAvailabilityDoctorSpecialtyUsersModel model)
        {
            if (model == null)
            {
                return BadRequest(new { Message = "Invalid doctor availability data." });
            }

            var result = await _doctorAvailabilityRepository.CreateDoctorAvailability(model);

            if (result == null)
            {
                return BadRequest(new { Message = "Unable to create doctor availability." });
            }

            return CreatedAtAction(nameof(GetDoctorAvailability), new { doctorId = result.DoctorId }, result);
        }

        [HttpPut("UpdateDoctorAvailability/{availabilityId}")]
        public async Task<ActionResult> UpdateDoctorAvailability(int availabilityId, [FromBody] DoctorAvailabilityDoctorSpecialtyUsersModel model)
        {
            if (model == null)
            {
                return BadRequest(new { Message = "Invalid doctor availability data." });
            }

            var result = await _doctorAvailabilityRepository.UpdateDoctorAvailability(availabilityId, model);

            if (result == null)
            {
                return NotFound(new { Message = "Doctor availability not found." });
            }

            return NoContent();
        }

        [HttpDelete("DeleteDoctorAvailability/{availabilityId}")]
        public async Task<ActionResult> DeleteDoctorAvailability(int availabilityId)
        {
            var result = await _doctorAvailabilityRepository.DeleteDoctorAvailability(availabilityId);

            if (!result)
            {
                return NotFound(new { Message = "Doctor availability not found." });
            }

            return NoContent();
        }
    }
}

