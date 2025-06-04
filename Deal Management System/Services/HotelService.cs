using Deal_Management_System.DTOs;
using Deal_Management_System.Models;
using Deal_Management_System.Repositories;

namespace Deal_Management_System.Services
{
    public class HotelService(IHotelRepository hotelRepository) : IHotelService
    {
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

    }
}
