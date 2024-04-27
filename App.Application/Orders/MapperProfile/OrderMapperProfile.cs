using App.core.Helpers;
using App.Data.GenericRepository;
using App.Domain.Constants.Enums;
using App.Domain.Orders;
using App.Domain.Orders.Dtos;
using App.Domain.Representatives;

namespace App.Application.Orders.MapperProfile;

public class OrderMapperProfile : Profile
{
    private ICurrentUser _currentUser { get; set; }
    private IRepository<Representative> _representativeRepository { get; set; }
    public OrderMapperProfile()
    {
        #region ListOrderDto
        CreateMap<Order, ListOrderDto>()
            .ForMember(dest => dest.RepresentativeName,
                opt => opt.MapFrom(src => src.Representative.UserInfo.Name))
            .ForMember
            (dest =>
                dest.Price,
                opt => opt.MapFrom
                    (
                     src => src.OrderProducts.Sum(op => op.Price)
                     - (src.Discount ?? 0)
                    )
            )
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.OrderProducts.Sum(op => op.Quantity)))
            .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.OrderStatus.ToString()));
        ;

        #endregion

        #region DetailsOrderDto
        CreateMap<Order, DetailsOrderDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.OrderProducts))
            .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.OrderProducts.Sum(op => op.Price) - (src.Discount ?? 0)))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Address + " " + src.Clint.Name))
            .ReverseMap()
            ;
        #endregion

        #region CreateOrderDto

        CreateMap<CreateOrderDto, Order>()
            .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => OrderStatus.Pending))
            .ForMember(dest => dest.OrderProducts, opt => opt.MapFrom(src => src.Products))
            .ForMember(dest => dest.RepresentativeId, opt => opt.MapFrom(src => GetCurruntUserId()))

            ;

        #endregion

        #region UpdateOrderDto

        CreateMap<UpdateOrderDto, Order>();

        #endregion
    }

    private int GetCurruntUserId()
    {
        var currentUser = _currentUser.Inject();
        var repository = _representativeRepository.Inject();
        var representativeId = repository.FirstOrDefault(x => x.UserInfo.Id == currentUser.UserId, u => u.Id);
        return representativeId;
    }
}