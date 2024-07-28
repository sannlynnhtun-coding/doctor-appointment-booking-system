namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos;

public class FeedbackDTO
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string Content { get; set; }
}