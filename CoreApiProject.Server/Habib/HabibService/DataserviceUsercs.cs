using CoreApiProject.Server.Habib.DTOS;
using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace CoreApiProject.Server.Habib.HabibService
{
	public class DataserviceUsercs : HabibInterFace.IDataservaceUser
	{
		private readonly MyDbContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public DataserviceUsercs(MyDbContext context, IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
			_context = context;
		}


		public string HashPassword(string password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
		}

		public bool VerifyPassword(string password, string hash)
		{
			return BCrypt.Net.BCrypt.Verify(password, hash);
		}

		public bool GetAllUserByID(int id, Habib.DTOS.DTOEditData _dto)
		{
			var user = _context.Users.Find(id);
			if (user != null)
			{
				user.FullName = _dto.FullName;
				user.Phone = _dto.Phone;
				user.Email = _dto.Email;
				_context.Users.Update(user);
				_context.SaveChanges();
				return true;
			}
			return false;

		}
		public List<User> GetAllUsers()
		{
			return _context.Users.ToList();
		}
		public List<Booking> GetBookingDataByID(int id)
		{
			var bookingData = _context.Bookings.Where(b => b.UserId == id).ToList();
			return bookingData;
		}
		public User GetUserByID(int id)
		{
			var user = _context.Users.Find(id);
			if (user != null)
			{
				return user;
			}
			return null;
		}
		public List<object> GetRatesbyuserid(int id)
		{
			var user = _context.Users.Find(id);

			if (user != null)
			{
				var rates = _context.Reviews
					.Where(r => r.UserId == id)
					.Include(r => r.Movie) 
					.Select(r => new
					{
						r.Rating,
						r.ReviewText,
						MovieTitle = r.Movie != null ? r.Movie.Title : "Unknown"
					})
					.ToList<object>();

				return rates;
			}
			return null;
		}

		public bool ChangePassword(int id, DTOS.ChangePassword change)
		{
			var user = _context.Users.Find(id);

			if (user != null)
			{
				if (user.Password == change.OldPassword)
				{
					if (change.NewPassword == change.OldPassword)
					{
						return false;
					}

					user.Password = change.NewPassword;
					_context.Users.Update(user);
					_context.SaveChanges();
					return true;
				}
			}

			return false;
		}

		// Tracks failed login attempts (email -> attempt count)
		// Static so it persists across all service instances (in-memory)
		private static readonly Dictionary<string, int> _failedAttempts = new();



		// Tracks blocked emails and when they were blocked (email -> block timestamp)
		// Static for the same reason as above
		private static readonly Dictionary<string, DateTime> _blockedEmails = new();





		public bool LogIn(LoginDTO user)
		{
			// Check if email is blocked
			if (_blockedEmails.TryGetValue(user.Email, out var blockTime) &&
				blockTime > DateTime.Now.AddMinutes(-1))
			{
				return false; // Still blocked
			}

			var logInUser = _context.Users.FirstOrDefault(x => x.Email == user.Email);

			if (logInUser != null && VerifyPassword(user.Password, logInUser.Password))
			{
				// Successful login - reset counters
				_failedAttempts.Remove(user.Email);
				_blockedEmails.Remove(user.Email);

				_httpContextAccessor.HttpContext?.Session.SetInt32("ID", logInUser.Id);
				return true;
			}

			// Failed login - track attempts
			if (_failedAttempts.ContainsKey(user.Email))
			{
				_failedAttempts[user.Email]++;

				// Block for 1 minute after 3 attempts
				if (_failedAttempts[user.Email] >= 3)
				{
					_blockedEmails[user.Email] = DateTime.Now;
				}
			}
			else
			{
				_failedAttempts[user.Email] = 1;
			}

			return false;
		}
		public bool SignUp( SignUpDTO user)
		{
			var dbUser = new Models.User();
			dbUser.FullName = user.FullName;
			dbUser.Email = user.Email;
			dbUser.Password = HashPassword(user.Password);
			dbUser.Phone = user.Phone;
			_context.Users.Add(dbUser);
			_context.SaveChanges();
			return true;
		}
		public bool ResetPassword(ResetPasswordDTO resetPassword)
		{
			var ID = _httpContextAccessor.HttpContext?.Session.GetInt32("ID");


			var userPass = _context.Users.Find(8);
			if (VerifyPassword(resetPassword.CurrentPassword, userPass.Password))
			{
				if (resetPassword.NewPassword == resetPassword.ConfirmNewPassword)
				{

					var newPass = new Models.User();
					userPass.Password = HashPassword(resetPassword.ConfirmNewPassword);
					_context.Users.Add(newPass);
					_context.SaveChanges();
					return true;
				}
				else
				{
					return false;
				}

			}
			return false;

		}
		//---Rating

		public bool AddReview(RatingDTO ratingDto)
		{
			var review = new Review
			{
				UserId = ratingDto.UserId,
				MovieId = ratingDto.MovieId,
				Rating = ratingDto.Rating,
				ReviewText = ratingDto.ReviewText,
				CreatedAt = DateTime.Now
			};

			_context.Reviews.Add(review);
			_context.SaveChanges();

			return true;
		}
		public bool CheckPaymentStatus(int userId)
		{
			return true;
		}
		public List<Movie> GetAllMovies()
		{
			return _context.Movies.ToList();
		}

	}
}
