using OrderAPI.Entities;
namespace OrderAPI.Repositories
{
    public interface IOrdersRepository
    {
        Task AddOrderAsync(Order order);
        Task<Order> GetOrderAsync(int id);
        Task<List<Order>> GetOrdersAsync();
    }
}
