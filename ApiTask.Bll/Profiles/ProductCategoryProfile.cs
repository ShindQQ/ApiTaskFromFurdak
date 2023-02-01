using ApiTaskCodeFirst.Bll.Models.ForInsert;
using ApiTaskCodeFirst.Dal.Entities;
using AutoMapper;

namespace ApiTask.Bll.Profiles;

public sealed class ProductCategoryProfile : Profile
{
    public ProductCategoryProfile()
    {
        CreateMap<ProductCategory, ProductCategoryForInsert>();
        CreateMap<ProductCategoryForInsert, ProductCategory>();
        CreateMap<ProductCategory, ProductCategoryForInsert>().ReverseMap();
    }
}
