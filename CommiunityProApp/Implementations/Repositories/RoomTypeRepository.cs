using CommunityProApp.Context;
using CommunityProApp.Entities;
using CommunityProApp.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CommunityProApp.Implementations.Repositories
{
    public class RoomTypeRepository : BaseRepository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public RoomType GetById(int id)
        {
            return _context.RoomTypes.Where(rt => rt.Id == id).Include(rt => rt.Rooms).SingleOrDefault();
        }
    }
}
