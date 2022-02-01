using CommunityProApp.Entities;

namespace CommunityProApp.Interfaces.Repositories
{
    public interface IRoomTypeRepository : IRepository<RoomType>
    {
        RoomType GetById(int id);
    }
}
