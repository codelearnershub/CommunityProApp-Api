using CommunityProApp.Dtos;
using CommunityProApp.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityProApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

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


    }
}
