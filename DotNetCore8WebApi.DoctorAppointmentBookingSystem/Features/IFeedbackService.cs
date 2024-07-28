using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Utils;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Features;

public interface IFeedbackService
{
    Task<Result<FeedbackDTO>> GiveFeedbackAsync(CreateFeedbackDTO feedback);
    Task<Result<IEnumerable<FeedbackDTO>>> GetFeedbacksAsync();
    Task<Result<FeedbackDTO>> GetFeedbackByIdAsync(int id);
}