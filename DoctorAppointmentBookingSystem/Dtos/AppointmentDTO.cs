namespace DoctorAppointmentBookingSystem.Dtos;

public class AppointmentDto
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public DateTime Date { get; set; }
    public string Slot { get; set; }
}