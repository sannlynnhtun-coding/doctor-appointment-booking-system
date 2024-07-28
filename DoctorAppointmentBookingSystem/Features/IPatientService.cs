namespace DoctorAppointmentBookingSystem.Features;

public interface IPatientService
{
    Task<Result<PatientDto>> RegisterPatientAsync(CreatePatientDto patient);
    Task<Result<IEnumerable<PatientDto>>> GetPatientsAsync();
    Task<Result<PatientDto>> GetPatientByIdAsync(int id);
}