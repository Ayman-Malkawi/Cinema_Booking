using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IData _data;
        public BookingController(IData data)
        {
            _data = data;
        }

        [HttpPost("book-public-room")]
        public IActionResult BookPublicRoom([FromBody] PublicBookingDTO dto)
        {
            var booking = new Booking
            {
                UserId = dto.UserId,
                RoomId = dto.RoomId,
                MovieId = dto.MovieId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                TotalPrice = dto.TotalPrice,
                PaymentMethod = dto.PaymentMethod,
                PaymentStatus = "Pending"
            };

            // تنفيذ العملية بشكل متزامن
            _data.AddBooking(booking);
            return Ok("Room booked successfully!");
        }

        [HttpGet("all")]
        public IActionResult GetAllBookings()
        {
            var bookings = _data.GetAllBookings();
            return Ok(bookings);
        }

        [HttpPut("cancel/{id}")]
        public IActionResult CancelBooking(int id)
        {
            _data.CancelBooking(id);
            return Ok("Booking canceled.");
        }


    }
}
