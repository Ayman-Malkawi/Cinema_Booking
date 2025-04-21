namespace CoreApiProject.Server.DTORequest
{
    public class AvailabilityScheduleDTO
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public int? PrivateRoomId { get; set; }
        public string AvailableDay { get; set; }
        public string StartTime { get; set; }  // Time in format "HH:mm"
        public string EndTime { get; set; }    // Time in format "HH:mm"
    }
}
