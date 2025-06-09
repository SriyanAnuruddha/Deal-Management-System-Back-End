using Deal_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Deal_Management_System.DTOs
{
    public class CreateDealDTO
    {
        public string Name { get; set; }

        public IFormFile VideoFile { get; set; }
        public List<Guid>? HotelIDs { get; set; }
    }
}
