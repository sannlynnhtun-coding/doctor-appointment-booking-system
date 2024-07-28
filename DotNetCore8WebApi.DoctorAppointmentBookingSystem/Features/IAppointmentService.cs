using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Utils;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Features;

public interface IAppointmentService
{
    Task<Result<AppointmentDTO>> BookAppointmentAsync(CreateAppointmentDTO appointment);
    Task<Result<IEnumerable<AppointmentDTO>>> GetAppointmentsAsync();
    Task<Result<AppointmentDTO>> GetAppointmentByIdAsync(int id);
    Task<Result<IEnumerable<AppointmentDTO>>> GetAppointmentsByDoctorIdAsync(int doctorId);
    Task<Result<IEnumerable<AppointmentDTO>>> GetAppointmentsByPatientIdAsync(int patientId);
}