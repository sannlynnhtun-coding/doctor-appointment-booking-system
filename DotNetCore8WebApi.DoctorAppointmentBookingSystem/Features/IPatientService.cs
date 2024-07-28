using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Models;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Features;

public interface IPatientService
{
    Task<Result<PatientDTO>> RegisterPatientAsync(CreatePatientDTO patient);
    Task<Result<IEnumerable<PatientDTO>>> GetPatientsAsync();
    Task<Result<PatientDTO>> GetPatientByIdAsync(int id);
}