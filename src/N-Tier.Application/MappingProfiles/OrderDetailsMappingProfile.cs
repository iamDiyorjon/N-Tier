using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Core.Entities;

namespace N_Tier.Application.MappingProfiles
{
    public class OrderDetailsMappingProfile : Profile
    {
        public OrderDetailsMappingProfile()
        {
            CreateMap<CreateOrderDetailsModel, OrderDetails>();
        }
    }
}
