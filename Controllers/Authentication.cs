using Microsoft.AspNetCore.Mvc;

namespace SampleApi.Authentication
{
    [ApiController]
    [Route("[controller]")]
    public class Authentication : ControllerBase
    {
        private readonly ILogger<Authentication> _logger;

        public Authentication(ILogger<Authentication> logger)
        {
            _logger = logger;
        }

        [HttpGet("headers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetHeaders()
        {
            return Ok(Request.Headers);
        }
    }
}