using AutoMapper;
using N_Tier.Application.Models.Category;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CreateCategoryModel, Category>().ReverseMap();
            CreateMap<UpdateCategoryModel, Category>().ReverseMap();
            CreateMap<Category, CategoryResponseModel>().ReverseMap();
        }
    }
}
