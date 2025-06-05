using Deal_Management_System.DTOs;
using Deal_Management_System.Models;

namespace Deal_Management_System.Services
{
    public interface IDealService
    {
        Task<Deal?> AddDeal(CreateDealDTO createDealDTO, IFormFile videoFile);

        Task<Deal?> AddMoreHotels(Guid dealId, AddHotelsDTO addHotelsDTO);

        Task<bool> DeleteDeal(Guid dealId);

        Task<List<Deal>> GetAllDeals();

        Task<Deal?> GetDealDetails(string slug);
    }
}
