using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private readonly ILogger<ExampleController> _logger;
    private readonly IExampleService _weatherForecastService;

    public ExampleController(ILogger<ExampleController> logger, IExampleService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet(Name = "RunExample")]
    public async Task<IEnumerable<int>> RunExample()
    {
        var res = await _weatherForecastService.RunExample();
        return res;
    }
}