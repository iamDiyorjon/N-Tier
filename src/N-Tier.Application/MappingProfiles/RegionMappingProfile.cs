using AutoMapper;
using CRUD.Domain.Models.Entities.Info;
using N_Tier.Application.Models.RegionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class RegionMappingProfile : Profile
    {
        public RegionMappingProfile()
        {
            CreateMap<CreateRegionModel, Region>().ReverseMap();
            CreateMap<UpdateRegionModel, Region>().ReverseMap();
            CreateMap<Region, RegionResponseModel>().ReverseMap();
        }
    }
}
