namespace CoreApiProject.Server.DTORequest
{
    public class PrivateRoomWithAvailabilityDto
    {
        public int Id { get; set; }
        public string? RoomName { get; set; }
        public string VipName { get; set; }
        public string VipDescription { get; set; }
        public decimal VipPrice { get; set; }
        public int Capacity { get; set; }

        public List<RoomAvailabilityDTO> Availability { get; set; }
    }

}
