using App.Domain.Products;
using App.Domain.Products.Dtos;

namespace App.Application.Products.MapperProfile;

public class ProductMapperProfile : Profile
{
    public ProductMapperProfile()
    {
        CreateMap<Product, DetailsProductDto>().ReverseMap();

        CreateMap<CreateProductDto, Product>().ReverseMap();

        CreateMap<UpdateProductDto, Product>().ReverseMap();

        CreateMap<Product, ListProductDto>().ReverseMap();
    }

}
