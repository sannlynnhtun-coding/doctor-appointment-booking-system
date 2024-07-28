namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Database.AppDbContextModels;

public partial class Feedback
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public string? Content { get; set; }

    public virtual Patient? Patient { get; set; }
}
