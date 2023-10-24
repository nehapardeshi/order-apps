using AutoMapper;
using OrderAPI.Models;

namespace OrderAPI.Mappings
{
    /// <summary>
    /// Mapper class for Entities and DTO
    /// </summary>
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            // Mapping used while creating order
            CreateMap<CreateOrderLineRequest, OrderAPI.Entities.OrderLine>();

            // Mapping used while returing order
            CreateMap<OrderAPI.Entities.OrderLine, OrderAPI.Models.OrderLine>();
            CreateMap<OrderAPI.Entities.Order, OrderAPI.Models.Order>();
        }
    }
}
