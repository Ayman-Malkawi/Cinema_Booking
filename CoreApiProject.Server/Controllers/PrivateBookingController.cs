using CoreApiProject.Server.DTO;
using CoreApiProject.Server.IDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateBookingController : ControllerBase
    {
        private readonly IPrivateBookingService _service;

        public PrivateBookingController(IPrivateBookingService service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PrivateBookingCreateDto dto)
        {
            var result = await _service.CreatePrivateBookingAsync(dto);
            return Ok(result);
        }

        [HttpGet("MyBookings/{userId}")]
        public async Task<IActionResult> MyBookings(int userId)
        {
            var list = await _service.GetPrivateBookingsByUserAsync(userId);
            return Ok(list);
        }

        [HttpPut("Cancel/{id}")]
        public async Task<IActionResult> Cancel(int id)
        {
            var result = await _service.CancelPrivateBookingAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("Details/{userId}")]
        public async Task<IActionResult> BookingDetails(int userId)
        {
            var result = await _service.GetUserBookingDetails(userId);
            return Ok(result);
        }
        

    }
}
