namespace CoreApiProject.Server.DTORequest
{
    public class PrivateRoomDto
    {
        public int RoomId { get; set; }

        public string VIPName { get; set; }

        public string VIPDescription { get; set; }

        public decimal VIPPrice { get; set; }

        public int Capacity { get; set; }

    }
}
