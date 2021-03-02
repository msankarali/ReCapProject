using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok("I am here!");
        }
    }
}