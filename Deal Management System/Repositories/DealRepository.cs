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

        public async Task<Deal?> CreateDeal(string name,string slug,string videoFileName)
        {

            var exists = await context.Deals.FirstOrDefaultAsync(d => d.Slug == slug);

            if(exists != null) // thorw already exists exception
            {
                return null;
            }

            Deal deal = new Deal
            {
                Name = name,
                Slug = slug,
                VideoURL = videoFileName
            };

            context.Deals.Add(deal);
            await context.SaveChangesAsync();

            return deal;
        }

        public async Task<Deal?> AddHotelsToDeal(Guid dealId,List<Guid> hotelIds)
        {
            var deal = await context.Deals
               .Include(d => d.Hotels)
               .FirstOrDefaultAsync(d => d.Id == dealId);

            if (deal == null) return null; // throw not found exeception if deal is not found return null

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
            return await context.Deals.Where(d => d.Slug == slug)
                .Include(d => d.Hotels).FirstOrDefaultAsync();
               
        }

        public async Task<string?> GetVideoFileName(Guid dealId)
        {
            var deal= await context.Deals.FirstOrDefaultAsync(d => d.Id == dealId);

            if (deal != null)
            {
                return deal.VideoURL;
            }

            return null;
        }
        
        public async Task<Deal?> UpdateVideo(Guid dealId,string fileName)
        {
            var deal = await context.Deals.SingleOrDefaultAsync(d => d.Id == dealId);

            if(deal != null)
            {
                deal.VideoURL = fileName;
                await context.SaveChangesAsync();
                return deal;
            }

            return null;

        }

        public async Task<Deal?> UpdateDealDetails(Guid dealId,string name,string slug,string fileName)
        {
            var deal = await context.Deals.SingleOrDefaultAsync(d => d.Id == dealId);

            if (deal != null)
            {
                deal.Name = name;
                deal.Slug = slug;
                deal.VideoURL = fileName;

                await context.SaveChangesAsync();
                return deal;
            }

            return null;
        }

        public async Task<List<Deal>?> RetriveDealsPerPage(int pageNumber)
        {
            var data = await context.Deals.OrderBy(d => d.Id).Skip((pageNumber - 1) * 2)
                .Take(2).ToListAsync();

            return data;
        }
    }
}
