using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos;
using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Models;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Features;

public class FeedbackService : IFeedbackService
{
    private readonly AppDbContext _context;

    public FeedbackService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<FeedbackDTO>> GiveFeedbackAsync(CreateFeedbackDTO feedbackDto)
    {
        var feedback = feedbackDto.ToEntity();
        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();
        return Result<FeedbackDTO>.Success(feedback.ToDto());
    }

    public async Task<Result<IEnumerable<FeedbackDTO>>> GetFeedbacksAsync()
    {
        var feedbacks = await _context.Feedbacks.ToListAsync();
        return Result<IEnumerable<FeedbackDTO>>.Success(feedbacks.Select(f => f.ToDto()));
    }

    public async Task<Result<FeedbackDTO>> GetFeedbackByIdAsync(int id)
    {
        var feedback = await _context.Feedbacks.FindAsync(id);
        if (feedback == null)
        {
            return Result<FeedbackDTO>.Failure("Feedback not found");
        }
        return Result<FeedbackDTO>.Success(feedback.ToDto());
    }
}