using AutoMapper;
using N_Tier.Application.Models.Order;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class OrderMappingProfile :Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<CreateOrderModel, Order>();
            CreateMap<UpdateOrderModel, Order>();
            CreateMap<Order, OrderResponseModel>();
        }
    }
}
