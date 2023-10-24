using Microsoft.EntityFrameworkCore;
using OrderAPI.Database;
using OrderAPI.Entities;

namespace OrderAPI.Repositories

{
    public class OrdersSqlRepository : IOrdersRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrdersSqlRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddOrderAsync(Order order)
        {
          _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order> GetOrderAsync(int id)
        => await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

       

        public async Task<List<Order>> GetOrdersAsync()
        => await _dbContext.Orders.ToListAsync();
    }
}
