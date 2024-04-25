using App.Domain.Users;
using App.Domain.Users.Permissions;
using App.Domain.Users.Permissions.Dtos;

namespace App.Application.Users.Permissions.MapperProfile;

public class PermissionMapperProfile : Profile
{
    public PermissionMapperProfile()
    {
        CreateMap<Permission, PermissionReadDto>().ReverseMap();

        CreateMap<PermissionWriteDto, Permission>()
            .ForMember(x => x.IsDeleted, opt => opt.Ignore())
            .ForMember(x => x.CreatedDate, opt => opt.Ignore())
            .ForMember(x => x.DeletedDate, opt => opt.Ignore())
            .ForMember(x => x.UpdateDate, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.DeletedBy, opt => opt.Ignore())
            .ForMember(x => x.UpdateBy, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<User, UserPermissionsDto>()
            .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.Id))
            .ForMember(x => x.Permission,
                opt => opt.MapFrom(x => x.Roles.SelectMany(role => role.Permissions.Select(permission => permission.EndPointName))))
            .ReverseMap();
    }

}
