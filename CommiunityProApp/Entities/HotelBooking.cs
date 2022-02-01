using CommunityProApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Entities
{
    public class HotelBooking : BaseEntity
    {
        public string ReferenceNumber { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public decimal RoomPrice { get; set; }

        public BookingStatus Status { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime? CheckOutDate { get; set; }

        public int NumberOfDays { get; set; }

        public int NumberOfAdults { get; set; }

    }
}
