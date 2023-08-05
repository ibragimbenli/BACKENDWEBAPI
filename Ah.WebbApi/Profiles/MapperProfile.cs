using Ah.Model.Dtos.Product;
using Ah.Model.Entities;
using AutoMapper;

namespace Ah.WebbApi.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductGetDto>().ForMember(dst => dst.CategoryId, src => src.MapFrom(src => src.Category.CategoryName));

            //CreateMap<Product, ProductDto>().ForMember(hedef => hedef.CategoryName, kaynak => kaynak.MapFrom(src => src.Category.CategoryName));
        }
    }
}
