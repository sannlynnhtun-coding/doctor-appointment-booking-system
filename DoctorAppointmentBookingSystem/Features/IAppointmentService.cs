namespace DoctorAppointmentBookingSystem.Features;

public interface IAppointmentService
{
    Task<Result<AppointmentDto>> BookAppointmentAsync(CreateAppointmentDto appointment);
    Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsAsync();
    Task<Result<AppointmentDto>> GetAppointmentByIdAsync(int id);
    Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByDoctorIdAsync(int doctorId);
    Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByPatientIdAsync(int patientId);
}