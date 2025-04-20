using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAvailabilityController : ControllerBase
    {
        private readonly IData _data;
        public RoomAvailabilityController(IData data)
        {
            _data = data;
        }


        [HttpGet("GetPrivateRoomsWithAvailability")]
        public IActionResult GetPrivateRoomsWithAvailability()
        {
            var rooms = _data.GetPrivateRoomsWithAvailability();
            return Ok(rooms);
        }


        [HttpPost("AddPrivateRoomWithAvailability")]
        public IActionResult AddPrivateRoomWithAvailability([FromBody] PrivateRoomWithAvailabilityDto dto)
        {
            _data.AddPrivateRoomWithAvailability(dto);
            return Ok(new { message = "Room and availability added successfully" });
        }


    }
}
