namespace DoctorAppointmentBookingSystem.Features;

public class PatientService : IPatientService
{
    private readonly AppDbContext _context;

    public PatientService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<PatientDto>> RegisterPatientAsync(CreatePatientDto patientDto)
    {
        var patient = patientDto.ToEntity();
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        return Result<PatientDto>.Success(patient.ToDto());
    }

    public async Task<Result<IEnumerable<PatientDto>>> GetPatientsAsync()
    {
        var patients = await _context.Patients.ToListAsync();
        return Result<IEnumerable<PatientDto>>.Success(patients.Select(p => p.ToDto()));
    }

    public async Task<Result<PatientDto>> GetPatientByIdAsync(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return Result<PatientDto>.Failure("Patient not found");
        }
        return Result<PatientDto>.Success(patient.ToDto());
    }
}