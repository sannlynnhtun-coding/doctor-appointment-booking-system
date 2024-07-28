namespace DoctorAppointmentBookingSystem.Features;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterPatient([FromBody] CreatePatientDto patientDto)
    {
        var result = await _patientService.RegisterPatientAsync(patientDto);
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetPatients()
    {
        var result = await _patientService.GetPatientsAsync();
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var result = await _patientService.GetPatientByIdAsync(id);
        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
    }
}