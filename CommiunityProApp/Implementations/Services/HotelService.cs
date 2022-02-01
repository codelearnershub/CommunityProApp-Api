using CommunityProApp.Dtos;
using CommunityProApp.Entities;
using CommunityProApp.Interfaces.Repositories;
using CommunityProApp.Interfaces.Services;
using CommunityProApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CommunityProApp.Implementations.Services
{

    public class HotelService : IHotelService
    {


        private void 
        static Dictionary<string, Dictionary<DateTime, int>> calender = new Dictionary<string, Dictionary<DateTime, int>>();
        
        

        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IHotelBookingRepository _hotelBookingRepository;


        private void CreateCalender(string name)
        {
            Dictionary<DateTime, int> date = new Dictionary<DateTime, int>();
            var dates = DateTime.Now;
            for (int i = 0; i < 365; i++)
            {
                date.Add(dates.AddDays(i),0);
            }

            calender.Add(name, date);
        }

        public HotelService(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository, IHotelBookingRepository hotelBookingRepository)
        {
            _hotelBookingRepository = hotelBookingRepository;

            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;

            
        }

        public BaseResponse AddRoomType(CreateRoomTypeRequestModel model)
        {
            var roomType = new RoomType
            {
                Name = model.Name,
                Image = model.Image,
                Image2 = model.Image2,
                Image3 = model.Image3,
                Price = model.Price,
                MaxNumberOfAdult = model.MaxNumberOfAdult,
                Description = model.Description
            };
            _roomTypeRepository.Create(roomType);
            CreateCalender(roomType.Name);

            return new BaseResponse
            {
                Message = "Created Succesfully",
                Status = true,
            };
        }

        public BaseResponse AddRoom(CreateRoomRequestModel model)
        {
            var room = new Room
            {
                RoomNumber = model.RoomNumber,
                RoomTypeId = model.RoomTypeId,
                Status = Enums.RoomAvailabilityStatus.Available
            };
            _roomRepository.Create(room);
            return new BaseResponse
            {
                Message = "Created Succesfully",
                Status = true,
            };
        }

        public IList<RoomTypeDto> GetRoomTypes()
        {
            return _roomTypeRepository.Get().Select(rT => new RoomTypeDto
            {
                Description = rT.Description,
                Id = rT.Id,
                Image= rT.Image,
                Image2 = rT.Image2,
                Image3 = rT.Image3, 
                MaxNumberOfAdult = rT.MaxNumberOfAdult,
                Name = rT.Name,
                Price = rT.Price,
            }).ToList();
        }

        public IList<RoomTypeDto> GetRoomTypes(int roomTypeId)
        {
            return new List<RoomTypeDto>();
        }

        public RoomTypeDto RoomTypeDetail(int id)
        {
            return new RoomTypeDto();
        }
        /* private IEnumerable<IList<int>> AvailableRoomsIds(int roomTypeId)
         {
             return _roomRepository.GetAll(r => r.RoomTypeId == roomTypeId && r.Status == Enums.RoomAvailabilityStatus.Available).ToList()
         }*/
        private SearchRoomDto Getavailableroom(CheckRoomAvailabilityModel model)
        {
            var dr = _roomRepository.Query().Include(a => a.Type).Where(r => r.RoomTypeId == model.RoomTypeId).FirstOrDefault();
            var room = _roomRepository.Query().Include(a => a.Type).Where(r => r.RoomTypeId == model.RoomTypeId)
                .ToList()
                .Select(r => new SearchRoomDto
                {
                    Id = r.Id,
                    Price = r.Type.Price,
                    RoomNumber = r.RoomNumber,
                    RoomTypeName = r.Type.Name,
                    CheckInDate = model.CheckInDate,
                 
                    NumberOfAdults = model.NumberOfAdults,
                    RoomImage = r.Type.Image
                })
                .FirstOrDefault(r => SearchRoom(model));


            return room;

        }



        //private bool IsAvailableBetweenDate(int roomId, DateTime checkInDate, DateTime checkOutDate)
        //{
        //    bool isAvailble = false;
        //    var bookings = _hotelBookingRepository.GetByRoomId(roomId).Where(b => b.CheckOutDate >= DateTime.Now).ToList();

        //    if (bookings.Count == 0) return isAvailble;

        //    foreach(var booking in bookings)
        //    {
        //        if ((booking.CheckOutDate < checkInDate) || (booking.CheckInDate > checkInDate && booking.CheckInDate > checkOutDate))
        //        {
        //            isAvailble = true;
        //            break;
        //        }
        //    }

        //    return isAvailble;
        //}

        public bool SearchRoom(CheckRoomAvailabilityModel model)
        {
            var roomType = _roomTypeRepository.Get(model.RoomTypeId);
            var roomTypeCalender = calender[roomType.Name];
            bool isAvailable = true;
            
            for(int k = 0; k < model.NumberOfDays; k++)
            {
                
                if(roomTypeCalender[model.CheckInDate.AddDays(k)] >= roomType.Rooms.Count)
                {
                    isAvailable = false;
                    break;
                }

            }
            return isAvailable;
        }
        public BookRoomInvoice BookRoom(CreateBookingRequestModel model)
        {

            var room = _roomRepository.Get(model.RoomId);

            var roomTypeCalender = calender[room.Type.Name];
            for (int k = 0; k < model.NumberOfDays; k++)
            {
                roomTypeCalender[model.CheckInDate.AddDays(k)] += 1;
            }
            var booking = new HotelBooking
            {
                NumberOfAdults = model.NumberOfAdults,
                CheckInDate = model.CheckInDate,
                NumberOfDays = model.NumberOfDays,
                CustomerId = model.CustomerId,
                ReferenceNumber = Guid.NewGuid().ToString().Substring(0, 7),
                RoomId = model.RoomId,
                RoomPrice = model.RoomPrice * model.NumberOfDays,
                Status = Enums.BookingStatus.Initialized,

            };
            _hotelBookingRepository.Create(booking);
            return new BookRoomInvoice
            {

            };
        }
    }
}
