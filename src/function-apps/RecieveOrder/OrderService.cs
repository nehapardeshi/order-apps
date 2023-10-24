using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RecieveOrder.Entities;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RecieveOrder
{
    /// <summary>
    /// Calls order API for creating new order
    /// </summary>
    public class OrderService
    {
        private readonly ILogger _logger;
        private const string OrderAPIUrlKeyName = "OrderAPIUrl";
        private readonly string _orderAPIUrl;

        public OrderService(ILogger logger)
        {
            _logger = logger;
            _orderAPIUrl = Environment.GetEnvironmentVariable(OrderAPIUrlKeyName);
            AssertConfigurations();
        }

        private void AssertConfigurations()
        {
            if (string.IsNullOrWhiteSpace(_orderAPIUrl))
            {
                throw new ArgumentNullException(OrderAPIUrlKeyName);
            }
        }
        /// <summary>
        /// Calls orderAPI to add a new order
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task AddOrderAsync(Order order)
        {
            // Create an instance of HttpClient
            using (HttpClient client = new HttpClient())
            {

                // Create a JSON content to send in the request body
                string jsonContent = JsonConvert.SerializeObject(order);
                HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Send the POST request
                HttpResponseMessage response = await client.PostAsync(_orderAPIUrl, content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    _logger.LogInformation("API response: " + responseContent);
                }
                else
                {
                    _logger.LogError("API request failed with status code: " + response.StatusCode);
                }
            }
        }
    }
}
