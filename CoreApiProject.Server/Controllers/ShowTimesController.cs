using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowTimesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetShowTimes()
        {
            var data = new[]
            {
                new { screen = "Screen 1", times = new[] { "1:05 PM", "4:00 PM", "9:00 PM" } },
                new { screen = "Screen 2", times = new[] { "3:00 PM" } },
                new { screen = "Screen 3", times = new[] { "9:05 AM", "10:00 PM" } },
                new { screen = "Screen 4", times = new[] { "9:05 AM", "11:00 AM", "3:00 PM", "7:00 PM", "10:00 PM", "11:00 PM" } },
                new { screen = "Screen 5", times = new[] { "9:05 AM", "12:00 PM", "1:00 PM", "3:00 PM" } }
            };

            return Ok(data);
        }
    }
}
