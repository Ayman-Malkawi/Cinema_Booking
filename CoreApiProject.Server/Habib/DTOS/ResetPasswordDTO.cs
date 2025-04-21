namespace CoreApiProject.Server.Habib.DTOS
{
	public class ResetPasswordDTO
	{
		public string CurrentPassword { get; set; }
		public string NewPassword { get; set; }
		public string ConfirmNewPassword { get; set; }
	}
}
