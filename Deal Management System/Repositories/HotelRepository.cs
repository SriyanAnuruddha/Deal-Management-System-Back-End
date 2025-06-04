using Deal_Management_System.Data;
using Deal_Management_System.DTOs;
using Deal_Management_System.Models;

namespace Deal_Management_System.Repositories
{
    public class HotelRepository(AppDBContext context) : IHotelRepository
    {
        public async Task<Hotel> CreateHotel(HotelDTO hotelDTO)
        {
            Hotel hotel = new Hotel();

            hotel.Name = hotelDTO.Name;
            hotel.Rate = hotelDTO.Rate;
            hotel.Amenities = hotelDTO.Amenities;

            context.Hotels.Add(hotel);
            await context.SaveChangesAsync();
            return hotel;
        }

        public List<Hotel> GetAllHotels()
        {
            throw new NotImplementedException();
        }

    }
}
