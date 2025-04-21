namespace CoreApiProject.Server.DTO
{
    public class PrivateBookingDetailsDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string RoomName { get; set; }
        public string MovieTitle { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentStatus { get; set; }
        public string Status { get; set; }
    }
}
