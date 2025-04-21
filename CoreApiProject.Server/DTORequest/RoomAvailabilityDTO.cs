namespace CoreApiProject.Server.DTORequest
{
    public class RoomAvailabilityDTO
    {
        public int Id { get; set; }
        public int? PrivateRoomId { get; set; }
        public string AvailableDay { get; set; }
        public TimeOnly? StartTime { get; set; }  // تغيير النوع إلى TimeOnly
        public TimeOnly? EndTime { get; set; }    // تغيير النوع إلى TimeOnly
    }

}
