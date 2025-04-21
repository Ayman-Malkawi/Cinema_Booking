using CoreApiProject.Server.DTO;
using CoreApiProject.Server.Models;

namespace CoreApiProject.Server.IDataService
{
    public interface IBookingService
    {
        Task<Booking> CreateBookingAsync(BookingCreateDto dto);
        Task<List<string>> GetBookedSeatsByMovieAsync(int movieId);
        Task<List<Booking>> GetBookingsByUserIdAsync(int userId);
        Task<Booking?> CancelBookingAsync(int id);
    }
}
