using Ah.Model.Dtos.Product;
using Ah.Model.Entities;
using AutoMapper;

namespace Ah.Business.Profiles
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Product, ProductGetDto>()
                .ForMember(dst => dst.CategoryName,
                            X => X.MapFrom(src => src.Category.CategoryName));

            CreateMap<ProductPostDto, Product>();
            CreateMap<ProductPutDto, Product>();
            //CreateMap<Product, ProductDto>().ForMember(hedef => hedef.CategoryName, kaynak => kaynak.MapFrom(src => src.Category.CategoryName));
        }
    }
}
