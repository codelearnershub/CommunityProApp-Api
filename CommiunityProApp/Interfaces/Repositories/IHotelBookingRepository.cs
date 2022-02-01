using CommunityProApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Interfaces.Repositories
{
    public interface IHotelBookingRepository : IRepository<HotelBooking>
    {
        public IEnumerable<HotelBooking> GetByRoomId(int roomId);
    }
}
