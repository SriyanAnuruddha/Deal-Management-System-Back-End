using Deal_Management_System.DTOs;
using Deal_Management_System.Models;
using Deal_Management_System.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deal_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController(IHotelService hotelService) : ControllerBase
    {

        [HttpPost]
        public IActionResult GetAllHotels(HotelDTO hotelDTO)
        {
            hotelService.AddHotel(hotelDTO);

            return Ok("Hotel is added!");
        }
    }
}
