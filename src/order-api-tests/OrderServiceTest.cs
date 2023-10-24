using NSubstitute;
using OrderAPI.Entities;
using OrderAPI.Repositories;
using OrderAPI.Services;

namespace OrderAPITest
{
    public class OrderServiceTest
    {
        private readonly IOrdersService _ordersService;
        private readonly IOrdersRepository _ordersRepository;

        public OrderServiceTest()
        {
            _ordersRepository = Substitute.For<IOrdersRepository>();
            _ordersService = new OrdersService(_ordersRepository);

        }


        [Fact]
        public async Task AddOrderTestAsync()
        {
            //Arrange
            var expectedCustomerNumber = "Cu001";
            var expectedOrderNumber = "O001";
            var expectedTotalAmount = 110;
            var orderDate = DateTime.UtcNow;


            var orderLines = new List<OrderLine>
            {
                new OrderLine { ItemNumber = 1, Price = 10, Quantity = 5 },
                new OrderLine { ItemNumber = 2, Price = 100, Quantity = 2 }
            };


            //Act
            var order = await _ordersService.AddOrderAsync(expectedOrderNumber, expectedCustomerNumber, orderDate, orderLines);

            //Assert
            Assert.NotNull(order);
            Assert.Equal(expectedOrderNumber, order.OrderNumber);
            Assert.Equal(expectedCustomerNumber, order.CustomerNumber);
            Assert.Equal(expectedTotalAmount, order.TotalAmount);
            Assert.Equal(orderLines.Count, order.OrderLines.Count);
        }

        [Fact]

        public async Task GetOrderAsync()
        {
            //Arrange
            int orderId = 1;
            string orderNo = "ORD01";
            string customerNo = "Cust001";

            _ordersRepository.GetOrderAsync(orderId).Returns(new Order
            {
                Id = orderId,
                OrderNumber = orderNo,
                CustomerNumber = customerNo
            });


            //Act

            var order = await _ordersRepository.GetOrderAsync(orderId);

            //Assert
            Assert.NotNull(order);
            Assert.Equal(orderId, order.Id);
            Assert.Equal(orderNo, order.OrderNumber);
            Assert.Equal(customerNo, order.CustomerNumber);

        }


    }
}