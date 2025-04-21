using CoreApiProject.Server.Models;

namespace CoreApiProject.Server.IDataService
{
    public interface IPrivateRoomService
    {
        Task<List<PrivateRoom>> GetAllPrivateRoomsAsync();
    }
}
