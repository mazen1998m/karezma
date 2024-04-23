using App.Domain.Documents;
using App.Domain.Documents.Dtos;

namespace App.Application.Documents.MapperProfile;

public class DocumentMapperProfile : Profile
{
    public DocumentMapperProfile()
    {
        CreateMap<Document, DocumentDetailsDto>().ReverseMap();


        CreateMap<CreateDocumentDto, Document>()
            .ForMember(x => x.IsDeleted, opt => opt.Ignore())
            .ForMember(x => x.CreatedDate, opt => opt.Ignore())
            .ForMember(x => x.DeletedDate, opt => opt.Ignore())
            .ForMember(x => x.UpdateDate, opt => opt.Ignore())
            .ForMember(x => x.CreatedBy, opt => opt.Ignore())
            .ForMember(x => x.DeletedBy, opt => opt.Ignore())
            .ForMember(x => x.UpdateBy, opt => opt.Ignore())
            .ReverseMap()
            ;




    }
}