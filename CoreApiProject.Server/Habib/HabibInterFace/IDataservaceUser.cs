using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiProject.Server.Habib.HabibInterFace
{
	public interface IDataservaceUser
	{
		public List<User> GetAllUsers();

		public bool GetAllUserByID(int id, Habib.DTOS.DTOEditData _dto);

		public List<Booking> GetBookingDataByID(int id);
	}
}
