using CoreApiProject.Server.Habib.DTOS;
using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly Habib.HabibInterFace.IDataservaceUser _dataserviceUserserviceUser;

		public UsersController(Habib.HabibInterFace.IDataservaceUser dataserviceUser)
		{
			_dataserviceUserserviceUser = dataserviceUser;
		}

		[HttpPut("EditUser/{id}")]
		public IActionResult GetAllUser(int id, Habib.DTOS.DTOEditData _dto)
		{
			var user = _dataserviceUserserviceUser.GetAllUserByID(id, _dto); ;
			if (user != null)
			{
				return Ok(user);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpGet("GetAllUsers")]
		public IActionResult GetAllUsers()
		{
			var users = _dataserviceUserserviceUser.GetAllUsers();
			if (users != null)
			{
				return Ok(users);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpGet("GetBookingDataByID/{id}")]
		public IActionResult GetBookingDataByID(int id)
		{
			var bookingData = _dataserviceUserserviceUser.GetBookingDataByID(id);
			if (bookingData != null)
			{
				return Ok(bookingData);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpGet("getUserByID/{id}")]
		public IActionResult GetUserByID(int id)
		{
			var user = _dataserviceUserserviceUser.GetUserByID(id);
			if (user != null)
			{
				return Ok(user);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpGet("getRates/{id}")]
		public IActionResult GetRatesbyuserid(int id)
		{
			var rates = _dataserviceUserserviceUser.GetRatesbyuserid(id);
			if (rates != null)
			{
				return Ok(rates);
			}
			else
			{
				return NotFound();
			}
		}

		[HttpPut("changepassword/{id}")]
		public IActionResult ChangePassword(int id, [FromBody] ChangePassword change)
		{
			var result = _dataserviceUserserviceUser.ChangePassword(id, change);
			if (result)
			{
				return Ok("Password changed successfully.");
			}
			else
			{
				return BadRequest("Old and new passwords must be different or old password is incorrect.");
			}
		}

		//[HttpPost("login")]
		//public IActionResult LogIn([FromBody] LoginDTO user)
		//{
		//	if (user == null)
		//	{
		//		return BadRequest();
		//	}
		//	else
		//	{
		//		var userLogIn = _dataserviceUserserviceUser.LogIn(user);
		//		if (userLogIn)
		//		{
		//			return Ok();
		//		}
		//		else
		//		{
		//			return NotFound();
		//		}
		//	}
		//}


		//[HttpPost("signUppp")]
		//public IActionResult signUppp([FromBody] SignUpDTO user)
		//{


		//	if (user == null)
		//	{
		//		return BadRequest();
		//	}
		//	else
		//	{
		//		var register = _dataserviceUserserviceUser.SignUp(user);
		//		if (register)
		//		{
		//			return Ok();
		//		}
		//		else
		//		{
		//			return BadRequest();
		//		}
		//	}


		//}

		[HttpPost("addRating")]
		public IActionResult AddReview([FromBody] RatingDTO ratingDto)
		{
			var paymentStatus = _dataserviceUserserviceUser.CheckPaymentStatus(ratingDto.UserId);
			if (!paymentStatus)
				return BadRequest("Payment not completed. Unable to add rating.");

			var result = _dataserviceUserserviceUser.AddReview(ratingDto);

			if (result)
				return Ok(new { message = "Rating added successfully!" });
			else
				return BadRequest("Error adding rating.");
		}

		[HttpGet("GetAllMovies")]
		public IActionResult GetAllMovies()
		{
			var movies = _dataserviceUserserviceUser.GetAllMovies();
			if (movies != null)
			{
				return Ok(movies);
			}
			else
			{
				return NotFound();
			}
		}

	}
}
