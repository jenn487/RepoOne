using MedicalAppointments.Persistance.Interfaces.Appointment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MedicalAppointments.Domain.Entities.Appointments;
using System.Collections.Generic;

namespace MedicalAppointment.Appointment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpGet("GetAppointments")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Appointment>>>> GetAppointments()
        {
            try
            {
                var result = await _appointmentRepository.GetAll();

                if (!result.Success)
                {
                    return BadRequest(new ApiResponse<IEnumerable<Appointment>>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null
                    });
                }

                return Ok(new ApiResponse<IEnumerable<Appointment>>
                {
                    Success = true,
                    Message = "Appointments retrieved successfully.",
                    Data = result.Data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = $"Internal server error: {ex.Message}",
                    Data = null
                });
            }
        }

        [HttpGet("GetAppointment/{id}")]
        public async Task<ActionResult<ApiResponse<Appointment>>> GetAppointmentById(int id)
        {
            try
            {
                var result = await _appointmentRepository.GetEntityBy(id);

                if (!result.Success)
                {
                    return NotFound(new ApiResponse<Appointment>
                    {
                        Success = false,
                        Message = "Appointment not found.",
                        Data = null
                    });
                }

                return Ok(new ApiResponse<Appointment>
                {
                    Success = true,
                    Message = "Appointment retrieved successfully.",
                    Data = result.Data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = $"Internal server error: {ex.Message}",
                    Data = null
                });
            }
        }

        [HttpPost("SaveAppointment")]
        public async Task<ActionResult<ApiResponse<Appointment>>> SaveAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null || !ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Invalid appointment data.",
                    Data = null
                });
            }

            try
            {
                var result = await _appointmentRepository.Save(appointment);

                if (!result.Success)
                {
                    return BadRequest(new ApiResponse<string>
                    {
                        Success = false,
                        Message = result.Message,
                        Data = null
                    });
                }

                return CreatedAtAction(nameof(GetAppointmentById), new { id = result.Data.Id }, new ApiResponse<Appointment>
                {
                    Success = true,
                    Message = "Appointment saved successfully.",
                    Data = result.Data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = $"Internal server error: {ex.Message}",
                    Data = null
                });
            }
        }

        [HttpPut("UpdateAppointment/{id}")]
        public async Task<ActionResult<ApiResponse<Appointment>>> UpdateAppointment(int id, [FromBody] Appointment appointment)
        {
            if (appointment == null || !ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<string>
                {
                    Success = false,
                    Message = "Invalid appointment data.",
                    Data = null
                });
            }

            try
            {
                var result = await _appointmentRepository.Update(id, appointment);

                if (!result.Success)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Message = "Appointment not found.",
                        Data = null
                    });
                }

                return Ok(new ApiResponse<Appointment>
                {
                    Success = true,
                    Message = "Appointment updated successfully.",
                    Data = result.Data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = $"Internal server error: {ex.Message}",
                    Data = null
                });
            }
        }

        [Authorize(Roles = "Admin, Doctor")]
        [HttpDelete("DisableAppointment/{id}")]
        public async Task<IActionResult> DisableAppointment(int id)
        {
            try
            {
                var result = await _appointmentRepository.Remove(id);

                if (!result.Success)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Message = "Appointment not found.",
                        Data = null
                    });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Message = $"Internal server error: {ex.Message}",
                    Data = null
                });
            }
        }
    }

}