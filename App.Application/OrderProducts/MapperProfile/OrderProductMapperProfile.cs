using App.Domain.OrderProducts;
using App.Domain.OrderProducts.Dtos;

namespace App.Application.OrderProducts.MapperProfile;

public class OrderProductMapperProfile : Profile
{
    public OrderProductMapperProfile()
    {
        CreateMap<OrderProduct, DetailsOrderProductDto>()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Product.Image))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Product.Model))
            .ReverseMap()
        ;


        CreateMap<CreateOrderProductDto, OrderProduct>().ReverseMap();

        CreateMap<UpdateOrderProductDto, OrderProduct>().ReverseMap();





    }
}
