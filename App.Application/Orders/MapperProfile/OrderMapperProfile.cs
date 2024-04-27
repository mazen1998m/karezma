using App.Domain.Orders;
using App.Domain.Orders.Dtos;

namespace App.Application.Orders.MapperProfile;

public class OrderMapperProfile : Profile
{
    public OrderMapperProfile()
    {
        CreateMap<Order, ListOrderDto>()
            .ForMember(dest => dest.RepresentativeName,
                opt => opt.MapFrom(src => src.Representative.UserInfo.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.OrderProducts.Sum(op => op.Price)))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.OrderProducts.Sum(op => op.Quantity)))
            .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus.ToString()));
        ;

        CreateMap<Order, DetailsOrderDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.OrderProducts.Sum(op => op.Price)))
            .ReverseMap()
            ;

        CreateMap<CreateOrderDto, Order>();

        CreateMap<UpdateOrderDto, Order>();

    }

}