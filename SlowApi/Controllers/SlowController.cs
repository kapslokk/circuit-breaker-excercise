using Microsoft.AspNetCore.Mvc;

namespace SlowApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SlowController : ControllerBase
{
    private readonly Counter _counter;
    private readonly ILogger<SlowController> _logger;

    public SlowController(ILogger<SlowController> logger, Counter counter)
    {
        _logger = logger;
        _counter = counter;
    }

    [HttpGet]
    public ActionResult Get()
    {
        try
        {
            return Ok(_counter.GetCount());
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}