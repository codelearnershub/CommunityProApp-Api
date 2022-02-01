using CommunityProApp.Entities;
using CommunityProApp.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommunityProApp.Dtos
{
    public class RoomDto
    {
        public string RoomNumber { get; set; }
        public int Id { get; set; }

        public decimal Price { get; set; }

       public string RoomTypeName { get; set; }

        public RoomAvailabilityStatus Status { get; set; }

        

    }
    public class SearchRoomDto
    {
        public string RoomNumber { get; set; }

        public int Id { get; set; }

        public decimal Price { get; set; }

        public string RoomTypeName { get; set; }

        public DateTime CheckInDate { get; set; }

       
        public int NumberOfDays { get; set; }
        public int NumberOfAdults { get; set; }
        public string RoomImage { get; set; }

    }
    public class RoomTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public decimal Price { get; set; }

        public int MaxNumberOfAdult { get; set; }
    }

    public class CreateRoomTypeRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public decimal Price { get; set; }

        public int MaxNumberOfAdult { get; set; }
    }

    public class CreateRoomRequestModel
    {
        public string RoomNumber { get; set; }
        public int RoomTypeId { get; set; }
    }

    public class CheckRoomAvailabilityModel
    {
        public DateTime CheckInDate { get; set; }

        //public DateTime CheckOutDate { get; set; }
        public int RoomTypeId { get; set; }
        public int NumberOfAdults { get; set; }

        public int NumberOfDays { get; set; }
    }
    public class CreateBookingRequestModel
    {
        public string ReferenceNumber { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public decimal RoomPrice { get; set; }

        public BookingStatus Status { get; set; }

        public DateTime CheckInDate { get; set; }

        public int NumberOfDays { get; set; }

        public int NumberOfAdults { get; set; }
    }

    public class BookRoomInvoice
    {
        public int  NumberOfAdults { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int CustomerId { get; set; }
        public Guid ReferenceNumber { get; set; }
        public int RoomId { get; set; }
        public decimal RoomPrice { get; set; }
        public BookingStatus Status { get; set; }

    }
}
