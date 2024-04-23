using App.Domain.Orders;
using App.Domain.Orders.Dtos;
using AutoMapper;

namespace App.Application.Orders.MapperProfile;

public class OrderMapperProfile : Profile
{
    public OrderMapperProfile()
    {
        CreateMap<Order, ListOrderDto>();

        CreateMap<Order, OrderDetailsDto>();

        CreateMap<CreateOrderDto, Order>();

        CreateMap<UpdateOrderDto, Order>();

    }
}
