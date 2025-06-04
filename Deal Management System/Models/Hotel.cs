namespace Deal_Management_System.Models
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public double Rate { get; set; }
        public string Amenities { get; set; }
        
        public List<Deal> Deals { get; set; }
    }
}
