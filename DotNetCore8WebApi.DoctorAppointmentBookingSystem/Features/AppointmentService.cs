using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Models;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Features;

public class AppointmentService : IAppointmentService
{
    private readonly AppDbContext _context;

    public AppointmentService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<AppointmentDTO>> BookAppointmentAsync(CreateAppointmentDTO appointmentDto)
    {
        var appointment = appointmentDto.ToEntity();
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
        return Result<AppointmentDTO>.Success(appointment.ToDto());
    }

    public async Task<Result<IEnumerable<AppointmentDTO>>> GetAppointmentsAsync()
    {
        var appointments = await _context.Appointments.ToListAsync();
        return Result<IEnumerable<AppointmentDTO>>.Success(appointments.Select(a => a.ToDto()));
    }

    public async Task<Result<AppointmentDTO>> GetAppointmentByIdAsync(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);
        if (appointment == null)
        {
            return Result<AppointmentDTO>.Failure("Appointment not found");
        }
        return Result<AppointmentDTO>.Success(appointment.ToDto());
    }

    public async Task<Result<IEnumerable<AppointmentDTO>>> GetAppointmentsByDoctorIdAsync(int doctorId)
    {
        var appointments = await _context.Appointments.Where(a => a.DoctorId == doctorId).ToListAsync();
        return Result<IEnumerable<AppointmentDTO>>.Success(appointments.Select(a => a.ToDto()));
    }

    public async Task<Result<IEnumerable<AppointmentDTO>>> GetAppointmentsByPatientIdAsync(int patientId)
    {
        var appointments = await _context.Appointments.Where(a => a.PatientId == patientId).ToListAsync();
        return Result<IEnumerable<AppointmentDTO>>.Success(appointments.Select(a => a.ToDto()));
    }
}