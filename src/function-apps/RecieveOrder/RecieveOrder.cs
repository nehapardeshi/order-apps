using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using RecieveOrder.Entities;
using System.Threading.Tasks;

namespace RecieveOrder
{
    public class RecieveOrder
    {
        [FunctionName("ServiceBus_RecieveOrder")]
        public async Task Run([ServiceBusTrigger("orders", Connection = "ServiceBus_ConnectionString")] Order order,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {order.OrderNumber}");

            var orderService = new OrderService(log);
            await orderService.AddOrderAsync(order);
        }
    }
}
