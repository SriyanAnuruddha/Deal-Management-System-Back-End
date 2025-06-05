using Deal_Management_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Deal_Management_System.DTOs
{
    public class CreateDealDTO
    {
        public string Name { get; set; }

        public string Slug { get; set; }
        public string VideoURL { get; set; }

        public List<Guid> HotelIDs { get; set; }
    }
}
