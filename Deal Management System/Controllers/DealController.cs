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
        public async Task<IActionResult> AddDeal([FromForm] CreateDealDTO createDealDTO)
        {
          
            var result = await dealService.AddDeal(createDealDTO);

            if (result is null)
            {
                return BadRequest("The deal is already exists!");
            }

            return Ok(result);
  
        }


        [Authorize(Roles = "admin")]
        [HttpPut("{dealId}/addhotels")]
        public async Task<IActionResult> AddHotelsToDeal(Guid dealId,AssignHotelsDTO addHotelsDTO)
        {
            var result = await dealService.AddMoreHotels(dealId, addHotelsDTO);

            if(result is null)
            {
                return NotFound("Deal Id is invalid!");
            }

            return Ok(result);
        }

        
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

        [Authorize(Roles = "admin")]
        [HttpPut("{dealId}")]
        public async Task<IActionResult> UpdateDealDetails(Guid dealId,[FromForm] UpdateDealDetailsDto dto)
        {
            var result = await dealService.UpdateDealDetails(dealId,dto);

            if (result is null)
            {
                return NotFound("Deal Id is invalid!");
            }

            return Ok(result);
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

        [HttpGet("id/{dealId}")]
        public async Task<IActionResult> GetDealDetailsById(Guid dealId)
        {
            var result = await dealService.GetDealDetailsById(dealId);

            if (result is null)
            {
                return NotFound("deal doesn't exists!");
            }

            return Ok(result);
        }



        [HttpGet("{dealId}/video")]
        public async Task<IActionResult> GetVideo(Guid dealId)
        {
            var videoStream = await dealService.GetVideo(dealId);
            if (videoStream == null)
            {
                return NotFound("video is not found!");
            }

            return File(videoStream, "video/mp4");
        }

        [HttpGet("deals-per-page/{pageNumber}")]
        public async Task<IActionResult> GetDealsPerPage(int pageNumber,int limit=10)
        {
            var deals = await dealService.GetDealsPerPage(pageNumber);

            if (deals == null || deals.Count == 0)
            {
                return NotFound("no deals found!");
            }

            return Ok(deals);
        }


        [HttpPatch("{dealid}")]
        public async Task<IActionResult> EditDealDetails(Guid dealid, [FromForm] UpdateDealDTO dto)
        {
            //Debug.WriteLine($" \n output is {dto.Hotels?[0].Name} \n ");


            var deal = await dealService.UpdateDeal(dealid, dto);

            if (deal == null)
            {
                return NotFound("Deal is not found");
            }

            return Ok(deal);

        }

    }

}
