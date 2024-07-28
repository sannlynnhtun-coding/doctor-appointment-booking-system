namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos;

public class CreateAppointmentDTO
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime Date { get; set; }
    public string Slot { get; set; }
}