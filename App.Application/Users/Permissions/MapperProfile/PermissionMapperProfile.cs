using App.Domain.Users;
using App.Domain.Users.Permissions.Dtos;

namespace App.Application.Users.Permissions.MapperProfile;

public class PermissionMapperProfile : Profile
{
    public PermissionMapperProfile()
    {
        CreateMap<Domain.Users.Permissions.Permission, PermissionReadDto>()
       .ForMember(x => x.CreatedDate, opt => opt.Ignore())
                    .ForMember(x => x.UpdateDate, opt => opt.Ignore())
                    .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                    .ForMember(x => x.UpdateBy, opt => opt.Ignore())
       ;

        CreateMap<PermissionWriteDto, Domain.Users.Permissions.Permission>()
            .ForMember(x => x.IsDeleted, opt => opt.Ignore())
            .ForMember(x => x.CreatedDate, opt => opt.Ignore())
            .ForMember(x => x.DeletedDate, opt => opt.Ignore())
            .ForMember(x => x.UpdateDate, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.DeletedBy, opt => opt.Ignore())
            .ForMember(x => x.UpdateBy, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(x => x.CreatedDate, opt => opt.Ignore())
            ;

        CreateMap<User, UserPermissionsDto>()
            .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.Id))
            .ForMember(x => x.Permission,
                opt => opt.MapFrom(x => x.Roles.SelectMany(role => role.Permissions.Select(permission => permission.EndPointName))))
            .ForMember(x => x.CreatedDate, opt => opt.Ignore())
            .ForMember(x => x.UpdateDate, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.UpdateBy, opt => opt.Ignore())
            .ReverseMap()
            ;
    }

}
