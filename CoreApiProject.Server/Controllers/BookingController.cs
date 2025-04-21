using CoreApiProject.Server.DTO;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService) { _bookingService = bookingService; }


  

        [HttpPost("Create")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateDto dto)
        {
            var result = await _bookingService.CreateBookingAsync(dto);
            return Ok(result);
        }

        [HttpGet("MyBookings/{userId}")]
        public async Task<IActionResult> GetUserBookings(int userId)
        {
            var bookings = await _bookingService.GetBookingsByUserIdAsync(userId);
            return Ok(bookings);
        }

        [HttpPut("Cancel/{id}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var result = await _bookingService.CancelBookingAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        

    }
}
