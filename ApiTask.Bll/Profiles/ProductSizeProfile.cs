using ApiTaskCodeFirst.Bll.Models.ForInsert;
using ApiTaskCodeFirst.Dal.Entities;
using AutoMapper;

namespace ApiTask.Bll.Profiles;

public sealed class ProductSizeProfile : Profile
{
    public ProductSizeProfile()
    {
        CreateMap<ProductSize, ProductSizeForInsert>();
        CreateMap<ProductSizeForInsert, ProductSize>();
        CreateMap<ProductSize, ProductSizeForInsert>().ReverseMap();
    }
}
