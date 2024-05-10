using App.core.EntityAndDtoStructure.DtoStructure;
using App.Domain.Products;
using App.Domain.Products.MobileDto;

namespace App.Application.Products.MapperProfile;


public class ProductMobileMapperProfile : Profile
{
    public ProductMobileMapperProfile()
    {
        #region List
        CreateMap<Product, ListProductDto>().ReverseMap();
        #endregion

        #region Details
        //CreateMap<Product, DetailsProductDto>().ReverseMap();
        #endregion

        #region Create
        //CreateMap<CreateProductDto, Product>().ReverseMap();
        #endregion

        #region Update
        //CreateMap<UpdateProductDto, Product>().ReverseMap();
        #endregion

        CreateMap<Product, IdNameDto>().ReverseMap();
    }
}

