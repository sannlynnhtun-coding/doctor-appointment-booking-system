namespace DoctorAppointmentBookingSystem.Features;

public class FeedbackService : IFeedbackService
{
    private readonly AppDbContext _context;

    public FeedbackService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<FeedbackDto>> GiveFeedbackAsync(CreateFeedbackDto feedbackDto)
    {
        var feedback = feedbackDto.ToEntity();
        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();
        return Result<FeedbackDto>.Success(feedback.ToDto());
    }

    public async Task<Result<IEnumerable<FeedbackDto>>> GetFeedbacksAsync()
    {
        var feedbacks = await _context.Feedbacks.ToListAsync();
        return Result<IEnumerable<FeedbackDto>>.Success(feedbacks.Select(f => f.ToDto()));
    }

    public async Task<Result<FeedbackDto>> GetFeedbackByIdAsync(int id)
    {
        var feedback = await _context.Feedbacks.FindAsync(id);
        if (feedback == null)
        {
            return Result<FeedbackDto>.Failure("Feedback not found");
        }
        return Result<FeedbackDto>.Success(feedback.ToDto());
    }
}