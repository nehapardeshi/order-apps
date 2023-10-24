using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using SendOrder.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SendOrder
{
    public static class SendOrder
    {
        [FunctionName("ServiceBus_SendOrder")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "orders")] List<Order> orders,
            ILogger log)
        {
            log.LogInformation("Send order request received.");

            var publisher = new OrderPublisher(log);
            await publisher.PublishOrderAsync(orders);

            return new OkObjectResult($"{orders.Count} order(s) request sent successfully.");
        }

    }
}
