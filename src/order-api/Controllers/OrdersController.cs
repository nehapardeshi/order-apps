using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.DTO;
using OrderAPI.Models;
using OrderAPI.Services;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("Application/json")] //for documenting the media type
    [Consumes("Application/json")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public OrdersController(IOrdersService ordersService, IMapper mapper)
        {
            _ordersService = ordersService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all the orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderAPI.Models.Order>))]
        public async Task<IActionResult> GetOrdersAsync()
        {
            try
            {

                var orders = new List<OrderAPI.Models.Order>();

                var ords = await _ordersService.GetOrdersAsync();
                if (ords.Any())
                    orders = _mapper.Map<List<OrderAPI.Models.Order>>(ords);

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error { Code = "InternalServerError", Message = ex.Message });
            }

        }

        /// <summary>
        /// To get an order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{order-id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderAPI.Models.Order))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]

        public async Task<IActionResult> GetOrder([FromRoute(Name = "order-id")] int orderId)
        {
            try
            {
                var order = await _ordersService.GetOrderAsync(orderId);
                if (order == null)
                    return NotFound(new Error { Code="OrderNotFound", Message = $"Order not found with Id {orderId}" });
            
                var odr = _mapper.Map<OrderAPI.Models.Order>(order);
                return Ok(odr);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error { Code = "InternalServerError", Message = ex.Message });
            }
        }

        /// <summary>
        /// Adds a new order
        /// </summary>
        /// <param name="orderDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderAPI.Models.Order))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error))]
        public async Task<IActionResult> AddOrderAsync([FromBody] CreateOrderRequest request)
        {
            try
            {
                var orderLines = _mapper.Map<List<OrderAPI.Entities.OrderLine>>(request.OrderLines);
                var order = await _ordersService.AddOrderAsync(request.OrderNumber, request.CustomerNumber, request.OrderDate, orderLines);
                var createdOrder = _mapper.Map<OrderAPI.Models.Order>(order);
                return Ok(createdOrder);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new Error { Code="InternalServerError", Message = ex.Message });
            }
        }
    }
}