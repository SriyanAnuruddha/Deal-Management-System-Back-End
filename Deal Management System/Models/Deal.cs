using System.ComponentModel.DataAnnotations;

namespace Deal_Management_System.Models
{
    public class Deal
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string VideoURL { get; set; }

        public List<Hotel> Hotels { get; set; }
    }
}
    