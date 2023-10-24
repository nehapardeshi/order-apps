namespace OrderAPI.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int ItemNumber { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
