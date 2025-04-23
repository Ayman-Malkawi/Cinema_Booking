using CoreApiProject.Server.DTORequest;

public class PrivateRoomDTO1
{
    //public int Id { get; set; }
    //public int RoomId { get; set; }
    //public string RoomName { get; set; }
    //public string VIPName { get; set; }
    //public string VIPDescription { get; set; }
    //public decimal VIPPrice { get; set; }
    //public int Capacity { get; set; }

    //public List<RoomAvailabilityDTO> Availability { get; set; } = new();
    public string VIPName { get; set; } = null!;
    public string VIPDescription { get; set; } = null!;
    public decimal VIPPrice { get; set; }
    public int Capacity { get; set; }

    public List<RoomAvailabilityDTO> Availability { get; set; } = new();

}
