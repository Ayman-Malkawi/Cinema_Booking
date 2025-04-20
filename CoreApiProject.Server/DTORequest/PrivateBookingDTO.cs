using CoreApiProject.Server.Models;

namespace CoreApiProject.Server.DTORequest
{
    public class PrivateBookingDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? PrivateRoomId { get; set; }
        public int? MovieId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? TotalPrice { get; set; }
        public string PaymentMethod { get; set; }

        // Navigation properties (اختياري لو عندك علاقات)
        //public User User { get; set; }
        //public PrivateRoom PrivateRoom { get; set; }
        //public Movie Movie { get; set; }
    }
}
