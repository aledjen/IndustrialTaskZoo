using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialTaskZooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeathCheckController : ControllerBase
    {
        [HttpGet("/healthcheck")]
        public IActionResult HealthCheck()
        {
            return Ok("OK");
        }
    }
}
