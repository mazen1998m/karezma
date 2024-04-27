using App.Domain.Clints;
using App.Domain.Clints.Dtos;

namespace App.Application.Clints.MapperProfile;

public class ClintMapperProfile : Profile
{
    public ClintMapperProfile()
    {
        CreateMap<Clint, ListClintDto>().ReverseMap();
        CreateMap<Clint, DetailsClintDto>().ReverseMap();
    }
}
