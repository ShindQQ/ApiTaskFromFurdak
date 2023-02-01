using ApiTaskCodeFirst.Bll.Models.ForInsert;
using ApiTaskCodeFirst.Dal.Entities;
using AutoMapper;

namespace ApiTask.Bll.Profiles;

public sealed class ProductSeasonProfile : Profile
{
    public ProductSeasonProfile()
    {
        CreateMap<ProductSeason, ProductSeasonForInsert>();
        CreateMap<ProductSeasonForInsert, ProductSeason>();
        CreateMap<ProductSeason, ProductSeasonForInsert>().ReverseMap();
    }
}
