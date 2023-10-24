using OrderAPI.Entities;
using OrderAPI.Repositories;

namespace OrderAPI.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;

        }

        /// <summary>
        /// Get an order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Order> GetOrderAsync(int id) => await _ordersRepository.GetOrderAsync(id);

        /// <summary>
        /// To add a new order
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <param name="customerNumber"></param>
        /// <param name="orderDate"></param>
        /// <param name="orderLines"></param>
        /// <returns></returns>
        public async Task<Order> AddOrderAsync(string orderNumber, string customerNumber, DateTime orderDate, List<OrderLine> orderLines)
        {
            var order = new Order
            {
                OrderNumber = orderNumber,
                CustomerNumber = customerNumber,
                OrderDate = orderDate,
                CreatedDate = DateTime.Now,
                TotalAmount = orderLines?.Sum(line => line.Price) ?? 0
            };

            if (orderLines.Any())
                order.OrderLines = orderLines;

            await _ordersRepository.AddOrderAsync(order);
            return order;
        }


        /// <summary>
        /// Get all orders
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetOrdersAsync()
        => await _ordersRepository.GetOrdersAsync();
    }
}
