using Deal_Management_System.DTOs;
using Deal_Management_System.Models;

namespace Deal_Management_System.Services
{
    public interface IDealService
    {
        Task<Deal?> AddDeal(CreateDealDTO createDealDTO);

        Task<Deal?> AddMoreHotels(Guid dealId, AddHotelsDTO addHotelsDTO);

        Task<bool> DeleteDeal(Guid dealId);
    }
}
