namespace CoreApiProject.Server.DTORequest
{
    public class RoomBookingDTO
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public string MovieName { get; set; }
        public DateOnly BookingDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
