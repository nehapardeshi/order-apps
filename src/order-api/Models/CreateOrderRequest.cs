namespace OrderAPI.Models
{
    public class CreateOrderRequest
    {
        public string OrderNumber { get; set; }
        public string CustomerNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public List<CreateOrderLineRequest> OrderLines { get; set; }
    }
}
