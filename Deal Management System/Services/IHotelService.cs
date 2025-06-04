using Deal_Management_System.DTOs;
using Deal_Management_System.Models;

namespace Deal_Management_System.Services
{
    public interface IHotelService
    {
        Task<Hotel?> AddHotel(HotelDTO hotelDTO);
    }
}
