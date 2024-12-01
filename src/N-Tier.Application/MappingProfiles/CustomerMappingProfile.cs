using AutoMapper;
using N_Tier.Application.Models.CustomerModels;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CreateCustomerModel, Customer>()
                .ForPath(c => c.Person.Age, o => o.MapFrom(src => src.Age))
                .ForPath(c => c.Person.Gender, o => o.MapFrom(src => src.Gender))
                .ForPath(c => c.Person.Name, o => o.MapFrom(src => src.Name)); 
            CreateMap<UpdateCustomerModel, Customer>().ReverseMap();
            CreateMap<Customer, CustomerResponseModel>().ReverseMap();
        }
    }
}
