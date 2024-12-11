using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace SMDotNet.Serilog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpGet] //methods are just API endpoint actions and don't specifically involve CRUD.
        public IActionResult Test() 
        {
            _logger.LogInformation("Hello!");
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            _logger.LogWarning("This is a warning log.");
            return StatusCode(201);
        }
    }
}
