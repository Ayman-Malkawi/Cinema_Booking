namespace CoreApiProject.Server.DTORequest
{
    //public class RoomDTO
    //{
    //    public string? RoomName { get; set; }
    //    public int? Capacity { get; set; }
    //    public string? RoomDescription { get; set; }
    //    public IFormFile? RoomImage { get; set; }
    //    public string? ImagePath { get; set; } 
    //    public int Id { get; set; }
    //    public string Image { get; set; }
    //}
    public class RoomDTO
    {
        public int Id { get; set; }
        public string? RoomName { get; set; }
        public int? Capacity { get; set; }
        public string? RoomDescription { get; set; }
        public string? Image { get; set; } // ✅ Manually entered URL
    }

}
