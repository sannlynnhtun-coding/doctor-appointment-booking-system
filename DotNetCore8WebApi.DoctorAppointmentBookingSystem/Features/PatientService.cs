using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Utils;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Features;

public class PatientService : IPatientService
{
    private readonly AppDbContext _context;

    public PatientService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<PatientDTO>> RegisterPatientAsync(CreatePatientDTO patientDto)
    {
        var patient = patientDto.ToEntity();
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        return Result<PatientDTO>.Success(patient.ToDto());
    }

    public async Task<Result<IEnumerable<PatientDTO>>> GetPatientsAsync()
    {
        var patients = await _context.Patients.ToListAsync();
        return Result<IEnumerable<PatientDTO>>.Success(patients.Select(p => p.ToDto()));
    }

    public async Task<Result<PatientDTO>> GetPatientByIdAsync(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return Result<PatientDTO>.Failure("Patient not found");
        }
        return Result<PatientDTO>.Success(patient.ToDto());
    }
}