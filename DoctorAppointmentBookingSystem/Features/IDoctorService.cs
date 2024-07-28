namespace DoctorAppointmentBookingSystem.Features;

public interface IDoctorService
{
    Task<Result<DoctorDto>> AddDoctorAsync(CreateDoctorDto doctor);
    Task<Result<IEnumerable<DoctorDto>>> GetDoctorsAsync();
    Task<Result<DoctorDto>> GetDoctorByIdAsync(int id);
}