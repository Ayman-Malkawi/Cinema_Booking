namespace CoreApiProject.Server.DTORequest
{
    public class RoomAvailabilityDTO 
    {
        //public int? RoomId { get; set; }
        //public string? AvailableDay { get; set; }

        //public string? StartTime { get; set; } // ✅ Time as string from frontend
        //public string? EndTime { get; set; }

        //public int Id { get; set; }
        //public int? PrivateRoomId { get; set; }
        public string AvailableDay { get; set; } = null!;
        public string StartTime { get; set; } = null!; // Send from Angular as string "HH:mm"
        public string EndTime { get; set; } = null!;
    }


}
