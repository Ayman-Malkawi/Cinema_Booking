using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAvailability : ControllerBase
    {
        private readonly IData _data;
        public RoomAvailability(IData data)
        {
            _data = data;
        }


        [HttpPost("addAvailability")]
        public IActionResult addAvailability([FromBody]RoomAvailabilityDTO AddAva)
        {

            if (AddAva == null)
                return BadRequest();


            if(_data.AddAvailability(AddAva))
            {
                return Ok();
            }


            return BadRequest();

        }

    }
}
