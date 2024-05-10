using App.Domain.Orders;
using App.Domain.Orders.MobileDto;

namespace App.Application.Orders.MapperProfile;

public class OrderMobileMapperProfile : Profile
{
    public OrderMobileMapperProfile()
    {
        #region ListOrderDto
        CreateMap<Order, ListOrderDto>()
            .ForMember(dest => dest.ClintName, opt => opt.MapFrom(src => src.Clint.Name))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts.Select(x => x.Product.Name).ToList()))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.OrderProducts.Sum(x => x.Price)))
            .ReverseMap();
        #endregion

        #region DetailsOrderDto
        CreateMap<Order, DetailsOrderDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src =>
            src.OrderProducts.Sum(op => op.Price * op.Quantity) - (src.Discount ?? 0) - (src.DeliveryFare)))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Address + " " + src.Clint.Name))
            .ForMember(dest => dest.SalesmanName, opt => opt.MapFrom(src => src.Representative.UserInfo.Name))
            .ReverseMap()
            ;
        #endregion


    }
}
