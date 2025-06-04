using Deal_Management_System.DTOs;
using Deal_Management_System.Models;
using Deal_Management_System.Repositories;

namespace Deal_Management_System.Services
{
    public class HotelService(IHotelRepository hotelRepository) : IHotelService
    {
        public Task<Hotel?> AddHotel(HotelDTO hotelDTO)
        {
            return hotelRepository.CreateHotel(hotelDTO);
        }
    }
}
