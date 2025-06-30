using Deal_Management_System.DTOs;
using Deal_Management_System.Models;
using Deal_Management_System.Repositories;

namespace Deal_Management_System.Services
{
    public class HotelService
    {

        private readonly HotelRepository hotelRepository;

        public HotelService(HotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        public async Task<Hotel?> GetHotelDetails(Guid hotelId)
        {
            return await hotelRepository.GetHotelDetails(hotelId);
        }

        public async Task<Hotel?> AddHotel(HotelDTO hotelDTO)
        {
            return await hotelRepository.CreateHotel(hotelDTO);
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await hotelRepository.GetAllHotels();
        }

        public async Task<bool> RemoveHotel(Guid id)
        {
            return await hotelRepository.DeleteHotel(id);
        }

        public async Task<Hotel?> UpdateHotelDetails(Guid id,HotelDTO hotelDTO)
        {
            return await hotelRepository.UpdateHotelDetails(id, hotelDTO);
        }


        public async Task<List<Hotel>> GetNonRelatedHotels(Guid dealId)
        {
            return await hotelRepository.GetNonRelatedHotels(dealId);
        }

        public async Task<bool> RemoveAssociatedHotelFromDeal(Guid dealId, Guid hotelId)
        {
            return await hotelRepository.RemoveHotelFromDeal(dealId, hotelId);
        }
    }
}
