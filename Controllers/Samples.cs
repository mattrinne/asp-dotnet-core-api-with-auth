using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Samples : ControllerBase
    {
        private readonly ILogger<Samples> _logger;

        public Samples(ILogger<Samples> logger)
        {
            _logger = logger;
        }

        [HttpGet("hello_world")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult HelloWorld()
        {
            return Ok("Hello World");
        }
    }
}