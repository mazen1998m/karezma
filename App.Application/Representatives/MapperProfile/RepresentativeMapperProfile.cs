using App.Domain.Representatives;
using App.Domain.Representatives.Dtos;
using App.Domain.Users;
namespace App.Application.Representatives.MapperProfile;

public class RepresentativeMapperProfile : Profile
{
    public IService<User> _userService { get; set; }

    public RepresentativeMapperProfile()
    {

        CreateMap<Representative, Representative>().ReverseMap();


        CreateMap<Representative, DetailsRepresentativeDto>()
             .ForMember(x => x.Name, opt => opt.MapFrom(e => e.UserInfo.Name))
             .ForMember(x => x.Phone, opt => opt.MapFrom(e => e.UserInfo.Phone))
             .ForMember(x => x.UserName, opt => opt.MapFrom(e => e.UserInfo.Email))
             .ForMember(x => x.UserId, opt => opt.MapFrom(e => e.UserInfo.Id))
             .ForMember(x => x.IsActive, opt => opt.MapFrom(e => e.UserInfo.IsActive))
             .ReverseMap()
            ;

        CreateMap<Representative, ListRepresentativeDto>()
            .ForMember(x => x.Name, opt => opt.MapFrom(e => e.UserInfo.Name))
             .ForMember(x => x.Phone, opt => opt.MapFrom(e => e.UserInfo.Phone))
             .ForMember(x => x.UserName, opt => opt.MapFrom(e => e.UserInfo.Email))
             .ForMember(x => x.UserId, opt => opt.MapFrom(e => e.UserInfo.Id))
             .ReverseMap()
            ;

        CreateMap<CreateRepresentativeDto, Representative>()
            .ForMember(x => x.UserInfo, opt => opt.MapFrom(e => new User
            {
                Name = e.Name,
                Phone = e.Phone,
                Email = e.UserName,
                Password = e.Password.ComputeSha256Hash(),
                IsActive = true,
                UserType = UserType.Representative,
            }))
            .ReverseMap()
             .ForMember(x => x.Name, opt => opt.MapFrom(e => e.UserInfo.Name))
             .ForMember(x => x.Phone, opt => opt.MapFrom(e => e.UserInfo.Phone))
             .ForMember(x => x.UserName, opt => opt.MapFrom(e => e.UserInfo.Email))
            ;



        CreateMap<UpdateRepresentativeDto, Representative>()
            .ForMember(x => x.UserInfo, opt => opt.MapFrom(e => new User
            {
                Id = e.UserId,
                Name = e.Name,
                Phone = e.Phone,
                Email = e.UserName,
                Password = GetPassword(e),
                IsActive = e.IsActive,
                UserType = UserType.Representative,
            }))
            .ReverseMap()
                .ForMember(x => x.Name, opt => opt.MapFrom(e => e.UserInfo.Name))
                 .ForMember(x => x.Phone, opt => opt.MapFrom(e => e.UserInfo.Phone))
                 .ForMember(x => x.UserName, opt => opt.MapFrom(e => e.UserInfo.Email))
                 .ForMember(x => x.UserId, opt => opt.MapFrom(e => e.UserInfo.Id))
                 .ForMember(x => x.IsActive, opt => opt.MapFrom(e => e.UserInfo.IsActive))
            ;

        CreateMap<Representative, CommisionReportDto>()
            .ForMember(x => x.Orders, opt => opt.MapFrom(e => e.Orders.Where(x => x.OrderStatus == OrderStatus.Delivered)))
            .ReverseMap()
            ;



    }

    public string GetPassword(UpdateRepresentativeDto userId)
    {
        _userService = _userService.Inject();
        var pass = _userService.FirstOrDefault(user => user.Id == userId.UserId, u => new { u.Id, u.Password }).Response.Password;
        return pass;
    }
}

