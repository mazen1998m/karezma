using app.core.EntityAndDtoStructure.DtoStructure;
using App.core.InjectionHelper;
using AutoMapper;

namespace App.core.Extensions;

public static class MapperExtensions
{
    private static readonly IMapper Mapper = GetMapper();

    private static IMapper GetMapper()
    {

        var mapper = Mapper.Inject();
        return mapper;
    }

    public static TDto Map<TDto>(this object entity) where TDto : Dto
    {

        return Mapper.Map<TDto>(entity);
    }


}