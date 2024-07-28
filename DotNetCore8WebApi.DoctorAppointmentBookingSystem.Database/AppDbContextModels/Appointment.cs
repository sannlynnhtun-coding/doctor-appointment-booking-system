namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Database.AppDbContextModels;

public partial class Appointment
{
    public int Id { get; set; }

    public int? DoctorId { get; set; }

    public int? PatientId { get; set; }

    public DateTime? Date { get; set; }

    public string? Slot { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }
}
