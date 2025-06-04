using Deal_Management_System.DTOs;
using Deal_Management_System.Models;

namespace Deal_Management_System.Repositories
{
    public interface IHotelRepository
    {
        List<Hotel> GetAllHotels();
        Task<Hotel> CreateHotel(HotelDTO hotelDTO);


    }
}
