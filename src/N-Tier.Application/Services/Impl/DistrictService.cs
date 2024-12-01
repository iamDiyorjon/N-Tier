using AutoMapper;
using CRUD.Domain.Models.Entities.Info;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Category;
using N_Tier.Application.Models.DistrictModels;
using N_Tier.Application.Models.RegionModels;
using N_Tier.DataAccess.Repositories;
using N_Tier.DataAccess.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.Impl
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository districtRepository;
        private readonly IMapper _mapper;

        public DistrictService(IDistrictRepository districtRepository, IMapper mapper)
        {
            this.districtRepository = districtRepository;
            this._mapper = mapper;
        }

        public async Task<CreateDistrictResponseModel> CreateAsync(CreateDistrictModel createCustomerModel, CancellationToken cancellationToken = default)
        {
            var region = _mapper.Map<District>(createCustomerModel);

            return new CreateDistrictResponseModel
            {
                Id = (await districtRepository.AddAsync(region)).Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var region = await districtRepository.GetFirstAsync(c => c.Id == id);

            return new BaseResponseModel
            {
                Id = (await districtRepository.DeleteAsync(region)).Id
            };
        }

        public List<DistrictResponseModel> GetAllAsyncWithQuerable()
        {
            var regions = districtRepository.GetAll();
            var result = regions.ToList();
            var result1 = _mapper.Map<List<DistrictResponseModel>>(result);

            return result1;
        }

        public async Task<UpdateDistrictResponseModel> UpdateAsync(Guid id, UpdateDistrictModel updateCustomerModel, CancellationToken cancellationToken = default)
        {
            var category = await districtRepository.GetFirstAsync(c => c.Id == id);
            _mapper.Map<District>(updateCustomerModel);

            return new UpdateDistrictResponseModel
            {
                Id = (await districtRepository.UpdateAsync(category)).Id
            };
        }
    }
}
