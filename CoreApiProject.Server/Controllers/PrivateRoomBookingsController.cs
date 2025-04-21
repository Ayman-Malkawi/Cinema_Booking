using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateRoomBookingsController : ControllerBase
    {
        private readonly IData _data;

        public PrivateRoomBookingsController(IData data)
        {
            _data = data;
        }


        [HttpGet("AllPrivateBookingsRooms")]
        public IActionResult GetAll() => Ok(_data.GetAll());


        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var booking = _data.GetById(id);
        //    if (booking == null) return NotFound();
        //    return Ok(booking);
        //}

        //[HttpPost("AddPrivateRoom")]
        //public IActionResult Add([FromBody] PrivateBookingDTO dto)
        //{
        //    _data.Add(dto);
        //    return Ok("Booking created");
        //}

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, [FromBody] PrivateBookingDTO dto)
        //{
        //    _data.Update(id, dto);
        //    return Ok("Booking updated");
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    _data.Delete(id);
        //    return Ok("Booking deleted");
        //}


    }
}
