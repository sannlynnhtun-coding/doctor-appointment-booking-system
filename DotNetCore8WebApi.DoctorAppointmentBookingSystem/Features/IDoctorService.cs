using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Models;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Features;

public interface IDoctorService
{
    Task<Result<DoctorDTO>> AddDoctorAsync(CreateDoctorDTO doctor);
    Task<Result<IEnumerable<DoctorDTO>>> GetDoctorsAsync();
    Task<Result<DoctorDTO>> GetDoctorByIdAsync(int id);
}