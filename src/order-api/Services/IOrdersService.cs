using OrderAPI.Entities;

namespace OrderAPI.Services
{
    public interface IOrdersService
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(int id);
        Task<Order> AddOrderAsync(string orderNumber, string customerNumber, DateTime orderDate, List<OrderLine> orderLines);
    }
}
