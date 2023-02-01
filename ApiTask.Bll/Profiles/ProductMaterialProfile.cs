using ApiTaskCodeFirst.Bll.Models.ForInsert;
using ApiTaskCodeFirst.Dal.Entities;
using AutoMapper;

namespace ApiTask.Bll.Profiles;

public sealed class ProductMaterialProfile : Profile
{
    public ProductMaterialProfile()
    {
        CreateMap<ProductMaterial, ProductMaterialForInsert>();
        CreateMap<ProductMaterialForInsert, ProductMaterial>();
        CreateMap<ProductMaterial, ProductMaterialForInsert>().ReverseMap();
    }
}
