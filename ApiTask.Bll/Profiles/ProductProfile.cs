using ApiTask.Bll.Models;
using ApiTaskCodeFirst.Dal.Entities;
using AutoMapper;

namespace ApiTask.Bll.Profiles;

public sealed class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductForInsertAndUpdateDto>();
        CreateMap<ProductForInsertAndUpdateDto, Product>();
        CreateMap<Product, ProductForInsertAndUpdateDto>().ReverseMap();
    }
}
