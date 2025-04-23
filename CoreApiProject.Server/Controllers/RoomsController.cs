using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IData _data;
        public RoomsController(IData data)
        {
            _data = data;
        }

        //[HttpPost("AddNewRoom")]
        //public async Task<IActionResult> AddNewRoom([FromForm] RoomDTO Room)
        //{
        //    if (Room?.RoomImage == null || Room.RoomImage.Length == 0)
        //        return BadRequest("Image is required");


        //    var fileExtension = Path.GetExtension(Room.RoomImage.FileName).ToLower();
        //    var fileName = $"{Guid.NewGuid()}{fileExtension}";
        //    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "rooms");

        //    Directory.CreateDirectory(folderPath);

        //    var filePath = Path.Combine(folderPath, fileName);

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await Room.RoomImage.CopyToAsync(stream);
        //    }


        //    Room.ImagePath = fileName;

        //    if (_data.AddNewRoom(Room))
        //        return Ok(new { ImageName = fileName });

        //    return BadRequest("Failed to save room");
        //}

        [HttpPost("AddNewRoom")]
        public IActionResult AddNewRoom([FromBody] RoomDTO room)
        {
            if (_data.AddNewRoom(room))
                return Ok("Room added successfully");

            return BadRequest("Failed to add room");
        }

        [HttpGet("GetAllRoom")]
        public IActionResult GetAllRoom()
        {


            var Room = _data.GetAllRooms();

            if (Room == null)
            {
                return BadRequest();
            }


            return Ok(Room);



        }

    }
}
