using Deal_Management_System.Models;

namespace Deal_Management_System.DTOs
{
    public class UpdateDealDTO
    {
        public string Name { get; set; }
        public IFormFile? VideoFile { get; set; }
        public List<HotelDTO> Hotels { get; set; }
    }
}
