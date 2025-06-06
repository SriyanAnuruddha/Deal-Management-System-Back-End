using Deal_Management_System.DTOs;
using Deal_Management_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Deal_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealController(IDealService dealService) : ControllerBase
    {
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> AddDeal([FromForm] CreateDealDTO createDealDTO,[FromForm] IFormFile videoFile)
        {
          
            if(videoFile == null || videoFile.Length <= 0)
            {
                return BadRequest("Please Insert a video!");
            }
            else
            {
                var result = await dealService.AddDeal(createDealDTO, videoFile);

                if (result is null)
                {
                    return BadRequest("The deal is already exists!");
                }

                return Ok(result);
            }
  
        }


        [Authorize(Roles = "admin")]
        [HttpPost("{dealId}/addhotels")]
        public async Task<IActionResult> AddHotelsToDeal(Guid dealId,AssignHotelsDTO addHotelsDTO)
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

        [HttpGet]
        public async Task<IActionResult> GetAllDeals()
        {
            var result = await dealService.GetAllDeals();

            if (result.Count == 0 )
            {
                return NotFound("no deals found!");
            }

            return Ok(result);
        }


        [HttpGet("{slug}")]
        public async Task<IActionResult> GetDealDetails(string slug)
        {
            var result = await dealService.GetDealDetails(slug);

            if (result is null)
            {
                return NotFound("deal doesn't exists!");
            }

            return Ok(result);
        }

    }


}
