using CommunityProApp.Context;
using CommunityProApp.Dtos;
using CommunityProApp.Entities;
using CommunityProApp.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Implementations.Repositories
{
    public class HotelBookingRepository : BaseRepository<HotelBooking>, IHotelBookingRepository
    {
        public HotelBookingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<HotelBooking> GetByRoomId(int roomId)
        {
            var bookings = _context.HotelBookings.Where(b => b.RoomId == roomId).ToList();
            return bookings;
        }
        
    }
}
