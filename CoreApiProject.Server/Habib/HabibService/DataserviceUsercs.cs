using CoreApiProject.Server.Models;

namespace CoreApiProject.Server.Habib.HabibService
{
	public class DataserviceUsercs : HabibInterFace.IDataservaceUser
	{
		private readonly MyDbContext _context;
		public DataserviceUsercs(MyDbContext context)
		{
			_context = context;
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

	}
}
