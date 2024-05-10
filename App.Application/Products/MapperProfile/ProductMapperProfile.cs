using App.Application.Files;
using App.Domain.Products;
using App.Domain.Products.Dtos;

namespace App.Application.Products.MapperProfile;

public class ProductMapperProfile : Profile
{
    private IFileService _fileService { get; }
    public ProductMapperProfile()
    {
        CreateMap<Product, DetailsProductDto>()
            //.ForMember(dest => dest.ImageBase64, opt => opt.MapFrom(src => GetImageBase64(src.Image)))
            .ReverseMap();

        CreateMap<CreateProductDto, Product>()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => GetImageUrl(src.Image)))
            .ReverseMap();

        CreateMap<UpdateProductDto, Product>()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageBase64.IsNullOrEmpty() ? src.Image : GetImageUrl(src.ImageBase64)))
            .ReverseMap();

        CreateMap<Product, ListProductDto>()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => GetImageBase64(src.Image)))
            .ReverseMap();

    }

    private string GetImageUrl(string image)
    {
        if (image.IsNullOrEmpty())
        {
            return string.Empty;
        }
        var fileService = _fileService.Inject();

        var file = fileService.FileSaveInFolder(image, "Product-img");
        return file.FileName;
    }

    private static string GetImageBase64(string image)
    {

        var fileService = new FileService();

        var file = fileService.GetFileBase64(image, "Product-img");
        return file;
    }

}
