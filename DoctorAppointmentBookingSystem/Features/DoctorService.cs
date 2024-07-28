namespace DoctorAppointmentBookingSystem.Features;

public class DoctorService : IDoctorService
{
    private readonly AppDbContext _context;

    public DoctorService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<DoctorDto>> AddDoctorAsync(CreateDoctorDto doctorDto)
    {
        var doctor = doctorDto.ToEntity();
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
        return Result<DoctorDto>.Success(doctor.ToDto());
    }

    public async Task<Result<IEnumerable<DoctorDto>>> GetDoctorsAsync()
    {
        var doctors = await _context.Doctors.ToListAsync();
        return Result<IEnumerable<DoctorDto>>.Success(doctors.Select(d => d.ToDto()));
    }

    public async Task<Result<DoctorDto>> GetDoctorByIdAsync(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null)
        {
            return Result<DoctorDto>.Failure("Doctor not found");
        }
        return Result<DoctorDto>.Success(doctor.ToDto());
    }
}