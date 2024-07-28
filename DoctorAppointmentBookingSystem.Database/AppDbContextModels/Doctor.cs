namespace DoctorAppointmentBookingSystem.Database.AppDbContextModels;

public partial class Doctor
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Speciality { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
