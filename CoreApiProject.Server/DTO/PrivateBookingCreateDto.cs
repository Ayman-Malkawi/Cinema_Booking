namespace CoreApiProject.Server.DTO
{
    public class PrivateBookingCreateDto
    {
        public int UserId { get; set; }
        public int PrivateRoomId { get; set; }
        public int MovieId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
