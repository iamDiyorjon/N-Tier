using AutoMapper;
using N_Tier.Application.Models.ProductModels;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles
{
    public class ProductMappingProfile :Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CreateProductModel, Product>().ReverseMap();
            CreateMap<UpdateProductModel, Product>().ReverseMap();
            CreateMap<Product,ProductResponseModel>().ReverseMap();
        }
    }
}
