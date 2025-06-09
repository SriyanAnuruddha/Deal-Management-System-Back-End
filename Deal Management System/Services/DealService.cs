using Deal_Management_System.DTOs;
using Deal_Management_System.Models;
using Deal_Management_System.Repositories;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Deal_Management_System.Services
{
    public class DealService(IDealRepository dealRepository):IDealService
    {
        public async Task<Deal?> AddDeal(CreateDealDTO createDealDTO)
        {
            string slug = GenerateSlug(createDealDTO.Name).ToString();
            string videoFileName = createDealDTO.VideoFile.FileName;

            await SaveVideo(createDealDTO.VideoFile);

            return await dealRepository.CreateDeal(createDealDTO.Name,slug, videoFileName,createDealDTO.HotelIDs);
        }

        public async Task<Deal?> AddMoreHotels(Guid dealId, AssignHotelsDTO addHotelsDTO)
        {
            return await dealRepository.AddHotelsToDeal(dealId,addHotelsDTO.HotelIds);
        }

        public async Task<bool> DeleteDeal(Guid dealId)
        {
            var videoFileName = await dealRepository.GetVideoFileName(dealId);
            if(videoFileName != null)
            {
                DeleteVideo(videoFileName);
            }

            return await dealRepository.DeleteDeal(dealId);
        }

        public async Task<Deal?> UpdateDealDetails(Guid dealId,UpdateDealDetailsDto dto)
        {
            var videoFileName = await dealRepository.GetVideoFileName(dealId);
            if (videoFileName != null)
            {
                DeleteVideo(videoFileName);
            }

            string newSlug = GenerateSlug(dto.Name);
            var deal = await dealRepository.UpdateDealDetails(dealId, dto.Name, newSlug, dto.VideoFile.FileName);

            if(deal != null)
            {
               await SaveVideo(dto.VideoFile);
               return deal;
            }

            return null;
        }

        public async Task<FileStream?> GetVideo(Guid dealId)
        {
            var videoFileName = await dealRepository.GetVideoFileName(dealId);
            if (videoFileName == null)
            {
                return null;
            }

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Videos");
            var fullPath = Path.Combine(uploadFolder, videoFileName);

            if (!File.Exists(fullPath))
            {
                return null;
            }

            return new FileStream(fullPath, FileMode.Open, FileAccess.Read);
        }

        public async Task<List<Deal>> GetAllDeals()
        {
            return await dealRepository.GetAllDeals();
        }

        
        public async Task<Deal?> GetDealDetails(string slug)
        {
            return await dealRepository.GetDealDetails(slug);
           
        }

        public async Task SaveVideo(IFormFile videoFile)
        {
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Videos");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var fullPath = Path.Combine(uploadFolder, videoFile.FileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await videoFile.CopyToAsync(stream);
            }
        }


        public void DeleteVideo(string fileName)
        {
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Videos");

            var fullPath = Path.Combine(uploadFolder, fileName);

            File.Delete(fullPath);
        }


        public string GenerateSlug(string name)
        {
            string slug = Regex.Replace(name.ToLower().Trim(), @"[^a-z0-9\s-]", "")
                                .Replace(" ", "-");
            return slug;
        }

    }
}
