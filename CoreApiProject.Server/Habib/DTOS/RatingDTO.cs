namespace CoreApiProject.Server.Habib.DTOS
{
	public class RatingDTO
	{
		public int UserId { get; set; } // معرف المستخدم الذي يضيف التقييم
		public int MovieId { get; set; } // معرف الفيلم الذي يتم تقييمه
		public int Rating { get; set; } // التقييم من 1 إلى 5
		public string ReviewText { get; set; } // نص التقييم، اختيارياً
	}
}
