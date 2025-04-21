using CoreApiProject.Server.Habib.DTOS;
using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Habib.HabibInterFace
{
	public interface IDataservaceUser
	{
		public List<User> GetAllUsers();

		public bool GetAllUserByID(int id, Habib.DTOS.DTOEditData _dto);

		public List<Booking> GetBookingDataByID(int id);

		public User GetUserByID(int id);

		public List<object> GetRatesbyuserid(int id);

		public bool ChangePassword(int id, DTOS.ChangePassword change);

		public bool LogIn(LoginDTO user);
		public bool SignUp(SignUpDTO user);

		string HashPassword(string password);
		bool VerifyPassword(string password, string hash);

		public bool ResetPassword(ResetPasswordDTO resetPassword);

		//----------------Rating----------------
		bool AddReview(RatingDTO ratingDto);
		bool CheckPaymentStatus(int userId);
		//------------------Movie----------------
		public List<Movie> GetAllMovies();

	}
}
