namespace DoctorAppointmentBookingSystem.Features;

public class AppointmentService : IAppointmentService
{
    private readonly AppDbContext _context;

    public AppointmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<AppointmentDto>> BookAppointmentAsync(CreateAppointmentDto appointmentDto)
    {
        var appointment = appointmentDto.ToEntity();
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
        return Result<AppointmentDto>.Success(appointment.ToDto());
    }

    public async Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsAsync()
    {
        var appointments = await _context.Appointments.ToListAsync();
        return Result<IEnumerable<AppointmentDto>>.Success(appointments.Select(a => a.ToDto()));
    }

    public async Task<Result<AppointmentDto>> GetAppointmentByIdAsync(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            return Result<AppointmentDto>.Failure("Appointment not found");
        }
        return Result<AppointmentDto>.Success(appointment.ToDto());
    }

    public async Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByDoctorIdAsync(int doctorId)
    {
        var appointments = await _context.Appointments.Where(a => a.DoctorId == doctorId).ToListAsync();
        return Result<IEnumerable<AppointmentDto>>.Success(appointments.Select(a => a.ToDto()));
    }

    public async Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByPatientIdAsync(int patientId)
    {
        var appointments = await _context.Appointments.Where(a => a.PatientId == patientId).ToListAsync();
        return Result<IEnumerable<AppointmentDto>>.Success(appointments.Select(a => a.ToDto()));
    }
}