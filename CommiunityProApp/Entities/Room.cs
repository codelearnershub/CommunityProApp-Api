using CommunityProApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Entities
{
    public class Room : BaseEntity
    {
        public string RoomNumber { get; set; }

        public int RoomTypeId { get; set; }

        public RoomType Type { get; set; }

        public RoomAvailabilityStatus Status { get; set; }

        public ICollection<HotelBooking> HotelBookings { get; set; } = new List<HotelBooking>();
    }
}
