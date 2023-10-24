namespace RecieveOrder.Entities;

public class OrderLine
{
    public int ItemNumber { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
