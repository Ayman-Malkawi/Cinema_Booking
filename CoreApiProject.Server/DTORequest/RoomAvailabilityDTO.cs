namespace CoreApiProject.Server.DTORequest
{
    public class RoomAvailabilityDTO
    {
        public int? RoomId { get; set; }

        public string? AvailableDay { get; set; }

        public TimeOnly? StartTime { get; set; }

        public TimeOnly? EndTime { get; set; }

    }

}
