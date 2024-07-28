using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookAppointment([FromBody] CreateAppointmentDTO appointmentDto)
        {
            var result = await _appointmentService.BookAppointmentAsync(appointmentDto);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAppointments()
        {
            var result = await _appointmentService.GetAppointmentsAsync();
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var result = await _appointmentService.GetAppointmentByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByDoctor(int doctorId)
        {
            var result = await _appointmentService.GetAppointmentsByDoctorIdAsync(doctorId);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAppointmentsByPatient(int patientId)
        {
            var result = await _appointmentService.GetAppointmentsByPatientIdAsync(patientId);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }
    }
}