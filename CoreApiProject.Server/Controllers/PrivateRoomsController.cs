using CoreApiProject.Server.IDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateRoomsController : ControllerBase
    {
        private readonly IPrivateRoomService _service;

        public PrivateRoomsController(IPrivateRoomService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var rooms = await _service.GetAllPrivateRoomsAsync();
            return Ok(rooms);
        }
    }
}
