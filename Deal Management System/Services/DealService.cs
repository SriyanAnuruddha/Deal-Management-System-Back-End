using Deal_Management_System.DTOs;
using Deal_Management_System.Models;
using Deal_Management_System.Repositories;
using System.Text.RegularExpressions;

namespace Deal_Management_System.Services
{
    public class DealService(IDealRepository dealRepository):IDealService
    {
        public async Task<Deal?> AddDeal(CreateDealDTO createDealDTO)
        {
            createDealDTO.Slug = GenerateSlug(createDealDTO.Name).ToString();

            return await dealRepository.CreateDeal(createDealDTO);
        }

        public async Task<Deal?> AddMoreHotels(Guid dealId, AddHotelsDTO addHotelsDTO)
        {
            return await dealRepository.AddHotelsToDeal(dealId,addHotelsDTO.HotelIds);
        }

        public async Task<bool> DeleteDeal(Guid dealId)
        {
            return await dealRepository.DeleteDeal(dealId);
        }

       
        public async Task<List<Deal>> GetAllDeals()
        {
            return await dealRepository.GetAllDeals();
        }

        public string GenerateSlug(string name)
        {
            string slug = Regex.Replace(name.ToLower().Trim(), @"[^a-z0-9\s-]", "")
                                .Replace(" ", "-");
            return slug;
        }

        public async Task<Deal?> GetDealDetails(string slug)
        {
            return await dealRepository.GetDealDetails(slug);
        }
    }
}
