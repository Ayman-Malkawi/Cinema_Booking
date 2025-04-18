using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly Habib.HabibInterFace.IDataservaceUser _dataserviceUser;

		public UsersController(Habib.HabibInterFace.IDataservaceUser dataserviceUser)
		{
			_dataserviceUser = dataserviceUser;
		}

		[HttpPut("GetAllUserByID")]

		public IActionResult GetAllUser(int id, Habib.DTOS.DTOEditData _dto)
		{
			var user = _dataserviceUser.GetAllUserByID(id, _dto); ;
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
			var users = _dataserviceUser.GetAllUsers();
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
			var bookingData = _dataserviceUser.GetBookingDataByID(id);
			if (bookingData != null)
			{
				return Ok(bookingData);
			}
			else
			{
				return NotFound();
			}
		}

	}
}
