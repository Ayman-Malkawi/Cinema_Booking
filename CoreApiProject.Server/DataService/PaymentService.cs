using CoreApiProject.Server.DTO;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.EntityFrameworkCore;

public class PaymentService : IPaymentService
{
    private readonly MyDbContext _context;

    public PaymentService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<Payment> CreatePaymentAsync(PaymentCreateDto dto)
    {
        var payment = new Payment
        {
            BookingId = dto.BookingId,
            Amount = dto.Amount,
            PaymentMethod = dto.PaymentMethod,
            PaymentStatus = dto.PaymentStatus,
            PaymentDate = DateTime.Now
        };

        _context.Payments.Add(payment);

        // تعديل الحجز المرتبط
        var booking = await _context.Bookings.FindAsync(dto.BookingId);
        if (booking != null)
        {
            var status = dto.PaymentStatus?.Trim();
            if (status == "Paid" || status == "Pending" || status == "Failed")
            {
                booking.PaymentStatus = status;
            }
            else
            {
                throw new Exception("Invalid PaymentStatus value. Allowed: Paid, Pending, Failed");
            }
        }

        await _context.SaveChangesAsync();
        return payment;
    }


    public async Task<List<Payment>> GetPaymentsByBookingIdAsync(int bookingId)
    {
        return await _context.Payments
            .Where(p => p.BookingId == bookingId)
            .ToListAsync();
    }
}
