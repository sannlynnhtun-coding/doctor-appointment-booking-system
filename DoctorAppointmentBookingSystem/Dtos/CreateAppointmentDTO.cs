namespace DoctorAppointmentBookingSystem.Dtos;

public class CreateAppointmentDto
{
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime Date { get; set; }
    public string Slot { get; set; }
}