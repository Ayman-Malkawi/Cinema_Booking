using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApiProject.Server.DataService
{
    public class PrivateRoomService : IPrivateRoomService
    {
        private readonly MyDbContext _context;

        public PrivateRoomService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<List<PrivateRoom>> GetAllPrivateRoomsAsync()
        {
            return await _context.PrivateRooms.ToListAsync();
        }
    }
}
