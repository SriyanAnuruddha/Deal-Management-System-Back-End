using Deal_Management_System.DTOs;
using Deal_Management_System.Models;

namespace Deal_Management_System.Repositories
{
    public interface IDealRepository
    {
        Task<Deal?> CreateDeal(CreateDealDTO createDealDTO);
        Task<Deal?> AddHotelsToDeal(Guid dealId, List<Guid> hotelIds);

        Task<bool> DeleteDeal(Guid dealId);

        Task<List<Deal>> GetAllDeals();

        Task<Deal?> GetDealDetails(string slug);

        Task<string?> GetVideoFileName(Guid dealId);

        Task<Deal?> UpdateVideo(Guid dealId, string fileName);

        Task<Deal?> UpdateDealDetails(Guid dealId, string name, string slug, string fileName);
    }
}
