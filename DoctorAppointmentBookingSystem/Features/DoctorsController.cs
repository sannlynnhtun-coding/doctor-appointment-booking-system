namespace DoctorAppointmentBookingSystem.Features;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoctorsController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddDoctor([FromBody] CreateDoctorDto doctorDto)
    {
        var result = await _doctorService.AddDoctorAsync(doctorDto);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetDoctors()
    {
        var result = await _doctorService.GetDoctorsAsync();
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctor(int id)
    {
        var result = await _doctorService.GetDoctorByIdAsync(id);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
}