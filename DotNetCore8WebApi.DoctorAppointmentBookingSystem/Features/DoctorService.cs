using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Utils;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Features
{
    public class DoctorService : IDoctorService
    {
        private readonly AppDbContext _context;

        public DoctorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<DoctorDTO>> AddDoctorAsync(CreateDoctorDTO doctorDto)
        {
            var doctor = doctorDto.ToEntity();
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return Result<DoctorDTO>.Success(doctor.ToDto());
        }

        public async Task<Result<IEnumerable<DoctorDTO>>> GetDoctorsAsync()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return Result<IEnumerable<DoctorDTO>>.Success(doctors.Select(d => d.ToDto()));
        }

        public async Task<Result<DoctorDTO>> GetDoctorByIdAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return Result<DoctorDTO>.Failure("Doctor not found");
            }
            return Result<DoctorDTO>.Success(doctor.ToDto());
        }
    }
}
