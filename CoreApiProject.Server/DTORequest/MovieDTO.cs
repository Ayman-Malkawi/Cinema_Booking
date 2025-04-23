namespace CoreApiProject.Server.DTORequest
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; } // مدة الفيلم بالدقائق
        public int CategoryId { get; set; } // ربط الفئة
        public string? CategoryName { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Image { get; set; }
        public decimal TicketPrice { get; set; }
        public int Rating { get; set; } // التقييم
        public bool IsVisible { get; set; } = true; // ✅ Add this line
    }
}
