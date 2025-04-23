using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateRoomController : ControllerBase
    {
        private readonly IData _data;

        public PrivateRoomController(IData data)
        {
            _data = data;
        }




        [HttpGet("AllPrivateRooms")]
        public IActionResult GetAllPrivateRooms()
        {
            try
            {
                var privateRooms = _data.GetAllPrivateRooms();
                return Ok(privateRooms);  // إرجاع الغرف الخاصة مع حالة النجاح
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //[HttpPost("AddPrivateRoom")]
        //public IActionResult AddPrivateRoom(PrivateRoomDTO1 dto)
        //{
        //    try
        //    {
        //        _data.AddPrivateRoom(dto);
        //        return CreatedAtAction(nameof(GetAllPrivateRooms), new { id = dto.Id }, dto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}








    }
}
