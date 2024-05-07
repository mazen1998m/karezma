using App.Domain.Users;
using App.Domain.Users.Auths;
using App.Domain.Users.Dtos;

namespace App.Application.Users.MapperProfile;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<User, LoginResponse>().ReverseMap();

        CreateMap<User, UserDetailsDto>().ReverseMap();


        CreateMap<User, UserListDto>().ReverseMap();


        CreateMap<CreateUserDto, User>()
            .ForMember(dto => dto.Password, opt => opt.MapFrom(entity => entity.Password.ComputeSha256Hash()))
            .ForMember(x => x.IsDeleted, opt => opt.Ignore())
            .ForMember(x => x.CreatedDate, opt => opt.Ignore())
            .ForMember(x => x.DeletedDate, opt => opt.Ignore())
            .ForMember(x => x.UpdateDate, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.DeletedBy, opt => opt.Ignore())
            .ForMember(x => x.UpdateBy, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateUserDto, User>()
            .ForMember(x => x.IsDeleted, opt => opt.Ignore())
            .ForMember(x => x.CreatedDate, opt => opt.Ignore())
            .ForMember(x => x.DeletedDate, opt => opt.Ignore())
            .ForMember(x => x.UpdateDate, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.DeletedBy, opt => opt.Ignore())
            .ForMember(x => x.UpdateBy, opt => opt.Ignore())
            .ReverseMap();


    }



}
