using AutoMapper;
using N_Tier.Application.Models.Customer;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CreateCustomerModel, Customer>().ReverseMap();
            CreateMap<UpdateCustomerModel, Customer>().ReverseMap();
            CreateMap<Customer, CustomerResponseModel>().ReverseMap();
        }
    }
}
