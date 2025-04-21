using CoreApiProject.Server.DTO;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApiProject.Server.DataService
{

    public class PrivateBookingService : IPrivateBookingService
    {
        private readonly MyDbContext _context;

        public PrivateBookingService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<PrivateBooking> CreatePrivateBookingAsync(PrivateBookingCreateDto dto)
        {
            var booking = new PrivateBooking
            {
                UserId = dto.UserId,
                PrivateRoomId = dto.PrivateRoomId,
                MovieId = dto.MovieId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                TotalPrice = dto.TotalPrice,
                PaymentStatus = dto.PaymentStatus,
                PaymentMethod = dto.PaymentMethod,
                BookingDate = DateTime.Now,
                Status = dto.Status
            };

            _context.PrivateBookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<List<PrivateBooking>> GetPrivateBookingsByUserAsync(int userId)
        {
            return await _context.PrivateBookings
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<PrivateBooking?> CancelPrivateBookingAsync(int id)
        {
            var booking = await _context.PrivateBookings.FindAsync(id);
            if (booking == null || booking.Status == "Cancelled")
                return null;

            booking.Status = "Cancelled";
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<List<PrivateBookingDetailsDto>> GetUserBookingDetails(int userId)
        {
            return await _context.PrivateBookings
                .Where(p => p.UserId == userId)
                .Include(p => p.User)
                .Include(p => p.Movie)
                .Include(p => p.PrivateRoom)
                //.ThenInclude(pr => pr.Room)
                .Select(p => new PrivateBookingDetailsDto
                {
                    Id = p.Id,
                    UserName = p.User.FullName,
                    RoomName = p.PrivateRoom.Vipname,
                    MovieTitle = p.Movie.Title,
                    StartTime = p.StartTime.Value,
                    EndTime = p.EndTime.Value,
                    TotalPrice = p.TotalPrice.Value,
                    PaymentStatus = p.PaymentStatus,
                    Status = p.Status
                })
                .ToListAsync();
        }

    }
}
