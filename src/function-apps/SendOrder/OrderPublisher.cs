using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SendOrder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendOrder
{
    /// <summary>
    /// Class to publish orders to service bus  
    /// </summary>
    public class OrderPublisher
    {
        private const string ServiceBusConnectionStringKeyName = "ServiceBus_ConnectionString";
        private const string ServiceBusQueueNameKeyName = "ServiceBus_QueueName";
        private readonly ILogger _logger;
        private readonly string _connectionString;
        private readonly string _queueName;

        public OrderPublisher(ILogger logger)
        {
            _logger = logger;
            _connectionString = Environment.GetEnvironmentVariable(ServiceBusConnectionStringKeyName);
            _queueName = Environment.GetEnvironmentVariable(ServiceBusQueueNameKeyName);
            AssertConfigurations();
        }

        private void AssertConfigurations()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                throw new ArgumentNullException(ServiceBusConnectionStringKeyName);
            }

            if (string.IsNullOrWhiteSpace(_queueName))
            {
                throw new ArgumentNullException(ServiceBusQueueNameKeyName);
            }
        }

        /// <summary>
        /// Publishes one or more orders to service bus queue
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public async Task PublishOrderAsync(List<Order> orders)
        {
            if (!orders.Any())
            {
                _logger.LogInformation("No orders to publish.");
                return;
            }

            // Create a ServiceBusClient
            await using var client = new ServiceBusClient(_connectionString);

            // Create a ServiceBusSender
            var sender = client.CreateSender(_queueName);

            try
            {
                foreach (var order in orders)
                {
                    // Create a message
                    var message = new ServiceBusMessage(JsonConvert.SerializeObject(order));

                    // Send the message
                    await sender.SendMessageAsync(message);
                    _logger.LogInformation($"Order Number {order.OrderNumber} published to queue {_queueName}");
                }
            }
            finally
            {
                await sender.DisposeAsync();
            }
        }
    }
}
