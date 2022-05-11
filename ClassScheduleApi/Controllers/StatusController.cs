namespace ClassScheduleApi.Controllers;

public class StatusController : ControllerBase
{
    [HttpGet("status")]
    public async Task<ActionResult> GetStatus()
    {
        //fake classroom stuff = go check status somehow
        var response = new StatusModel { Message = "good", LastChecked = DateTime.Now };
        return Ok(response);
    }
}