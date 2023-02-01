using ApiTaskCodeFirst.Bll.Models.ForInsert;
using ApiTaskCodeFirst.Dal.Entities;
using AutoMapper;

namespace ApiTask.Bll.Profiles;

public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductForInsert>();
        CreateMap<ProductForInsert, Product>();
        CreateMap<Product, ProductForInsert>().ReverseMap();
    }
}
