namespace CoreApiProject.Server.DTO
{
    public class BookingCreateDto
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public int MovieId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string? Seat1 { get; set; }

        public string? Seat2 { get; set; }

        public string? Seat3 { get; set; }
    }
}
