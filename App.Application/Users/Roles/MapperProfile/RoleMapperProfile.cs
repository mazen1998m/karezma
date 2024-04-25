using App.Domain.Users.Roles;
using App.Domain.Users.Roles.Dtos;
namespace App.Application.Users.Roles.MapperProfile;

public class RoleMapperProfile : Profile
{
    public RoleMapperProfile()
    {
        CreateMap<Role, RoleReadDto>()

        .ForMember(x => x.UserRoles, opt => opt.Ignore())
        .ForMember(x => x.RolePermissions, opt => opt.Ignore())
;

        CreateMap<RoleWriteDto, Role>()
            .ForMember(x => x.IsDeleted, opt => opt.Ignore())
            .ForMember(x => x.CreatedDate, opt => opt.Ignore())
            .ForMember(x => x.DeletedDate, opt => opt.Ignore())
            .ForMember(x => x.UpdateDate, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.DeletedBy, opt => opt.Ignore())
            .ForMember(x => x.UpdateBy, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<RoleDto, Role>().ReverseMap();
    }
}

