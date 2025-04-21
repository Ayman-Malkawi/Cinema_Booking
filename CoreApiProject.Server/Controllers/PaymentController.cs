using CoreApiProject.Server.DTO;
using CoreApiProject.Server.IDataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PaymentCreateDto dto)
        {
            var payment = await _service.CreatePaymentAsync(dto);
            return Ok(payment);
        }

        [HttpGet("ByBooking/{bookingId}")]
        public async Task<IActionResult> GetByBooking(int bookingId)
        {
            var list = await _service.GetPaymentsByBookingIdAsync(bookingId);
            return Ok(list);
        }
    }
}
