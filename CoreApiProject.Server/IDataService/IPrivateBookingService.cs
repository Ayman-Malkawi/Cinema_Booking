using CoreApiProject.Server.DTO;
using CoreApiProject.Server.Models;

namespace CoreApiProject.Server.IDataService
{
    public interface IPrivateBookingService
    {
        Task<PrivateBooking> CreatePrivateBookingAsync(PrivateBookingCreateDto dto);
        Task<List<PrivateBooking>> GetPrivateBookingsByUserAsync(int userId);
        Task<PrivateBooking?> CancelPrivateBookingAsync(int id);
        Task<List<PrivateBookingDetailsDto>> GetUserBookingDetails(int userId);
    }
}
