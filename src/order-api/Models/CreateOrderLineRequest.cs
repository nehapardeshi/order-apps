namespace OrderAPI.Models
{
    public class CreateOrderLineRequest
    {
        public int ItemNumber { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
