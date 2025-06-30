using Deal_Management_System.DTOs;
using Deal_Management_System.Models;
using Deal_Management_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deal_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        private HotelService hotelService;

        public HotelsController(HotelService hotelService)
        {
           this.hotelService = hotelService;
        }

        [HttpGet("{hotelId}")]
        public async Task<ActionResult<Hotel>> GetHotelDetails(Guid hotelId)
        {
            var response = await hotelService.GetHotelDetails(hotelId);

            if (response != null)
            {
                return Ok(response);
            }
            return NotFound(new { message ="Hotel is not found!" });

        }

        //[Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<Hotel>> AddHotel(HotelDTO hotelDTO)
        {
            var response = await hotelService.AddHotel(hotelDTO);

            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Can't add hotel!");

        }

        //[Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveHotel(Guid id)
        {
            var response = await hotelService.RemoveHotel(id);

            if (response is true)
            {
                return Ok(new{ message = "hotel removed successfully!" });
            }
            return BadRequest(new { message = "invalid hotel id!" });
        }


        [HttpGet()]
        public async Task<ActionResult> GetAllHotels()
        {
            List<Hotel> hotels = await hotelService.GetAllHotels();

            if(hotels.Count == 0)
            {
                return NotFound("No Hotels Found!");
            }

            return Ok(hotels);
        }


        //[Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHotelDetails(Guid id,[FromBody] HotelDTO hotelDTO)
        {
            var result = await hotelService.UpdateHotelDetails(id, hotelDTO);

            if(result is null)
            {
                return NotFound("Hotel id is invalid!");
            }

            return Ok(result);
        }

        [HttpGet("non-related-hotels/{dealID}")]
        public async Task<ActionResult> UpdateHotelDetails(Guid dealID)
        {
            var result = await hotelService.GetNonRelatedHotels(dealID);

            if (result is null)
            {
                return NotFound("Deak id is invalid!");
            }

            return Ok(result);
        }

        [HttpDelete("remove-hotel/{dealId}/{hotelId}")]
        public async Task<ActionResult> RemoveHotelFromDeal(Guid dealId, Guid hotelId)
        {
            bool result = await hotelService.RemoveAssociatedHotelFromDeal(dealId, hotelId);

            if (result)
            {
                return Ok(new { message = "Hotel successfully removed!" });

            }
            else
            {
                return NotFound(new { error = "can't removed hotel" });
            }
        }


    }
}
