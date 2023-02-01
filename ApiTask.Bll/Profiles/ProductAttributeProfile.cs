using ApiTaskCodeFirst.Bll.Models.ForInsert;
using ApiTaskCodeFirst.Dal.Entities;
using AutoMapper;

namespace ApiTask.Bll.Profiles;

public sealed class ProductAttributeProfile : Profile
{
    public ProductAttributeProfile()
    {
        CreateMap<ProductAttribute, ProductAttributeForInsert>();
        CreateMap<ProductAttributeForInsert, ProductAttribute>();
        CreateMap<ProductAttribute, ProductAttributeForInsert>().ReverseMap();
    }
}
