namespace CoreApiProject.Server.DTORequest
{
    public class CreatePrivateRoomDTO
    {
        public int RoomId { get; set; }
        public string VIPName { get; set; }
        public string VIPDescription { get; set; }
        public decimal VIPPrice { get; set; }
        public int Capacity { get; set; }
        public List<AvailabilityScheduleDTO> Availabilities { get; set; } = new List<AvailabilityScheduleDTO>();
    }
}
