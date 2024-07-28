using DotNetCore8WebApi.DoctorAppointmentBookingSystem.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore8WebApi.DoctorAppointmentBookingSystem.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbacksController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost("give")]
        public async Task<IActionResult> GiveFeedback([FromBody] CreateFeedbackDTO feedbackDto)
        {
            var result = await _feedbackService.GiveFeedbackAsync(feedbackDto);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetFeedbacks()
        {
            var result = await _feedbackService.GetFeedbacksAsync();
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeedback(int id)
        {
            var result = await _feedbackService.GetFeedbackByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }
    }
}