namespace OrderAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string CustomerNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
