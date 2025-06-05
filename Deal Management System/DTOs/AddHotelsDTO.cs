using System.ComponentModel.DataAnnotations;

namespace Deal_Management_System.DTOs
{
    public class AddHotelsDTO
    {
        public List<Guid> HotelIds { get; set; }
    }
}
