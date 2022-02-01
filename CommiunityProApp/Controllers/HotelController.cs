using CommunityProApp.Dtos;
using CommunityProApp.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private string filePath = "C:\\Users\\ABDUL LATEEF RAHEEM\\source\\repos\\CommiunityProApp\\CommiunityProApp\\Images"; 

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("Search")]
        public IActionResult SearchAvailableRooms([FromBody] CheckRoomAvailabilityModel model)
        {

            var searchRooms = _hotelService.SearchRoom(model);
            return Ok(searchRooms);
        }

        [HttpPost("CreateRoomType")]
        public IActionResult CreateRoomType([FromBody] CreateRoomTypeRequestModel model/*, IFormFile roomTypeImage, IFormFile roomTypeImage1, IFormFile roomTypeImage2*/)
        {
            /*if (roomTypeImage != null && roomTypeImage1 != null && roomTypeImage2 != null)
            {
                string roomTypeImagePath = Path.Combine(filePath, "RoomTypeImage");
                string roomTypeImage1PhotoPath = Path.Combine(filePath, "RoomTypeImage");
                string roomTypeImage2PhotoPath = Path.Combine(filePath, "RoomTypeImage");
                Directory.CreateDirectory(roomTypeImagePath);
                Directory.CreateDirectory(roomTypeImage1PhotoPath);
                Directory.CreateDirectory(roomTypeImage2PhotoPath);
                string contentType = roomTypeImage.ContentType.Split('/')[1];
                string contentType1 = roomTypeImage1.ContentType.Split('/')[1];
                string contentType2 = roomTypeImage2.ContentType.Split('/')[1];
                string photoImage = $"RMT{Guid.NewGuid()}.{contentType}";
                string photoImage1 = $"RMT{Guid.NewGuid()}.{contentType1}";
                string photoImage2 = $"RMT{Guid.NewGuid()}.{contentType2}";
                string fullPath = Path.Combine(roomTypeImagePath, photoImage);
                string fullPath1 = Path.Combine(roomTypeImage1PhotoPath, photoImage1);
                string fullPath2 = Path.Combine(roomTypeImage2PhotoPath, photoImage2);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    roomTypeImage.CopyTo(fileStream);

                }
                using (var fileStream = new FileStream(fullPath1, FileMode.Create))
                {
                    roomTypeImage1.CopyTo(fileStream);

                }
                using (var fileStream = new FileStream(fullPath2, FileMode.Create))
                {
                    roomTypeImage2.CopyTo(fileStream);

                }
                model.Image = photoImage;
                model.Image2 = photoImage1;
                model.Image3 = photoImage2;

            }*/
            var roomType = _hotelService.AddRoomType(model);
            return Ok(roomType);
        }
        
        [HttpPost("createRoom")]
        public IActionResult CreateRoom([FromBody]CreateRoomRequestModel model)
        {
            var room = _hotelService.AddRoom(model);
            return Ok(room);
        }
    }
}
