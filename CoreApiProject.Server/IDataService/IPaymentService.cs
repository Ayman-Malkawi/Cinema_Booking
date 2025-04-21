using CoreApiProject.Server.DTO;
using CoreApiProject.Server.Models;

namespace CoreApiProject.Server.IDataService
{
    public interface IPaymentService
    {
        Task<Payment> CreatePaymentAsync(PaymentCreateDto dto);
        Task<List<Payment>> GetPaymentsByBookingIdAsync(int bookingId);
    }
}
