using Deal_Management_System.Data;
using Deal_Management_System.DTOs;
using Deal_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Deal_Management_System.Repositories
{
    public class DealRepository(AppDBContext context):IDealRepository
    {

        public async Task<Deal?> CreateDeal(CreateDealDTO createDealDTO)
        {

            var exists = await context.Deals.FirstOrDefaultAsync(d => d.Slug == createDealDTO.Slug);

            if(exists != null) // check deal is already exists!
            {
                return null;
            }

            Deal deal = new Deal
            {
                Name = createDealDTO.Name,
                Slug = createDealDTO.Slug,
                VideoURL = createDealDTO.VideoURL
            };

            context.Deals.Add(deal);
            await context.SaveChangesAsync();

            //!NOTE this code needs to be changed
            if(createDealDTO.HotelIDs.Count != 0 || createDealDTO.HotelIDs != null)
            {

               return await AddHotelsToDeal(deal.Id, createDealDTO.HotelIDs);
         
            }

            return deal;
        }

        public async Task<Deal?> AddHotelsToDeal(Guid dealId,List<Guid> hotelIds)
        {
            var deal = await context.Deals
               .Include(d => d.Hotels)
               .FirstOrDefaultAsync(d => d.Id == dealId);

            if (deal == null) return null; // if deal is not found return null

            var hotelsToAdd = await context.Hotels
                .Where(h => hotelIds.Contains(h.Id))
                .ToListAsync();

            foreach (var hotel in hotelsToAdd)
            {
                if (!deal.Hotels.Any(h => h.Id == hotel.Id))
                {
                     deal.Hotels.Add(hotel);
                }
            }

            await context.SaveChangesAsync();

            return deal;
        }

        public async Task<bool> DeleteDeal(Guid dealId)
        {
            var deal = await context.Deals.FirstOrDefaultAsync(d => d.Id == dealId);

            if(deal is null)
            {
                return false;
            }

            context.Deals.Remove(deal);
            await context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Deal>> GetAllDeals()
        {
            return await context.Deals.ToListAsync(); ;
        }

        public async Task<Deal?> GetDealDetails(string slug)
        {
            return await context.Deals.Where(d => d.Slug == slug).Include(d => d.Hotels).FirstOrDefaultAsync();
               
        }
    }
}
