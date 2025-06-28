using Deal_Management_System.Data;
using Deal_Management_System.DTOs;
using Deal_Management_System.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> DeleteHotel(Guid id)
        {
            var hotel = await context.Hotels.FirstOrDefaultAsync(h => h.Id == id);

            if(hotel is null)
            {
                return false;
            }

            context.Hotels.Remove(hotel);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            List<Hotel> hotels = await context.Hotels.ToListAsync();

            return hotels;
        }

        public async Task<Hotel?> UpdateHotelDetails(Guid id,HotelDTO hotelDTO)
        {
            var hotel = await context.Hotels.SingleOrDefaultAsync(h => h.Id == id);

            if(hotel is null)
            {
                return null;
            }

            hotel.Name = hotelDTO.Name;
            hotel.Rate = hotelDTO.Rate;
            hotel.Amenities = hotelDTO.Amenities;

            await context.SaveChangesAsync();
            return hotel;
        }

        public async Task<List<Hotel>> GetNonRelatedHotels(Guid dealId)
        {
            var hotels = await context.Hotels.Where(h => h.Deals.All(d => d.Id != dealId)).ToListAsync();

            return hotels;
        }
    }
}
