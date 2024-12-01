using AutoMapper;
using CRUD.Domain.Models.Entities.Info;
using N_Tier.Application.Models.DistrictModels;
using N_Tier.Application.Models.RegionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.MappingProfiles
{
    public class DistrictMappingProfile : Profile
    {
        public DistrictMappingProfile()
        {
            CreateMap<CreateDistrictModel, District>().ReverseMap();
            CreateMap<UpdateDistrictModel, District>().ReverseMap();
            CreateMap<District, DistrictResponseModel>().ReverseMap();
        }
    }
}
