using Deal_Management_System.DTOs;
using Deal_Management_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deal_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealController(IDealService dealService) : ControllerBase
    {
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AddDeal(CreateDealDTO createDealDTO)
        {
            var result = await dealService.AddDeal(createDealDTO);

            if(result is null)
            {
                return BadRequest("The deal is already exists!");
            }

            return Ok(result);
        }


        [Authorize(Roles = "admin")]
        [HttpPost("{dealId}/addhotels")]
        public async Task<IActionResult> AddHotelsToDeal(Guid dealId,AddHotelsDTO addHotelsDTO)
        {
            var result = await dealService.AddMoreHotels(dealId, addHotelsDTO);

            if(result is null)
            {
                return NotFound("Deal Id is invalid!");
            }

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{dealId}")]
        public async Task<IActionResult> RemoveDeal(Guid dealId)
        {
            var result = await dealService.DeleteDeal(dealId);

            if (result is false)
            {
                return NotFound("Deal Id is invalid!");
            }

            return Ok("Deal is succesfully deleted!");
        }


    }


}
