namespace DoctorAppointmentBookingSystem.Features;

public interface IFeedbackService
{
    Task<Result<FeedbackDto>> GiveFeedbackAsync(CreateFeedbackDto feedback);
    Task<Result<IEnumerable<FeedbackDto>>> GetFeedbacksAsync();
    Task<Result<FeedbackDto>> GetFeedbackByIdAsync(int id);
}