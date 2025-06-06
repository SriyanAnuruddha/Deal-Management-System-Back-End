using System.ComponentModel.DataAnnotations;

namespace Deal_Management_System.DTOs
{
    public class AssignHotelsDTO
    {
        public List<Guid> HotelIds { get; set; }
    }
}
