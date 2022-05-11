namespace ClassScheduleApi.Controllers;

[Route("schedule")]
public class ScheduleController : ControllerBase
{
    private readonly FileScheduleAdapter _fileScheduleAdapter;

    public ScheduleController(FileScheduleAdapter fileScheduleAdapter)
    {
        _fileScheduleAdapter = fileScheduleAdapter;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var response = _fileScheduleAdapter.GetClassList();
        return Ok(response);
    }
}
