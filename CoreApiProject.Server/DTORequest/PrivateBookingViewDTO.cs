namespace CoreApiProject.Server.DTORequest
{
    public class PrivateBookingViewDTO
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string RoomName { get; set; }
        public DateOnly BookingDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentStatus { get; set; }
        public string Status { get; set; }
    }
}
