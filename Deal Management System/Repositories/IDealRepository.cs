using Deal_Management_System.DTOs;
using Deal_Management_System.Models;
using System.Threading.Tasks;

namespace Deal_Management_System.Repositories
{
    public interface IDealRepository
    {
        Task<Deal?> CreateDeal(string name, string slug, string videoFileName);
        Task<Deal?> AddHotelsToDeal(Guid dealId, List<Guid> hotelIds);

        Task<bool> DeleteDeal(Guid dealId);

        Task<List<Deal>> GetAllDeals();

        Task<Deal?> GetDealDetails(string slug);

        Task<string?> GetVideoFileName(Guid dealId);

        Task<Deal?> UpdateVideo(Guid dealId, string fileName);

        Task<Deal?> UpdateDealDetails(Guid dealId, string name, string slug, string fileName);

        Task<List<Deal>?> RetriveDealsPerPage(int pageNumber);

        Task<Deal?> GetDealDetailsById(Guid id);

        Task<Deal?> UpdateDeal(Guid dealId, string slug, string name, string fileName, List<Hotel> hotels);


    }
}
