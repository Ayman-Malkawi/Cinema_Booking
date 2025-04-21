using CoreApiProject.Server.DTO;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApiProject.Server.DataService
{
    public class BookingService : IBookingService
    {
        private readonly MyDbContext _context;

        public BookingService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> CreateBookingAsync(BookingCreateDto dto)
        {
            var booking = new Booking
            {
                UserId = dto.UserId,
                RoomId = dto.RoomId,
                MovieId = dto.MovieId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                TotalPrice = dto.TotalPrice,
                PaymentStatus = dto.PaymentStatus,
                PaymentMethod = dto.PaymentMethod,
                BookingDate = DateTime.Now,
                Cancelled = false,
                Seat1 = dto.Seat1,
                Seat2 = dto.Seat2,
                Seat3 = dto.Seat3
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<List<string>> GetBookedSeatsByMovieAsync(int movieId)
        {
            return await _context.Bookings
                .Where(b => b.MovieId == movieId && !(b.Cancelled ?? false))
                .SelectMany(b => new[] { b.Seat1, b.Seat2, b.Seat3 })
                .Where(s => s != null)
                .ToListAsync();
        }

        public async Task<List<Booking>> GetBookingsByUserIdAsync(int userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<Booking?> CancelBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null || booking.Cancelled == true)
                return null;

            booking.Cancelled = true;
            booking.CancellationDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return booking;
        }
    }
}
