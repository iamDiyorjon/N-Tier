using AutoMapper;
using CRUD.Domain.Models.Entities.Info;
using N_Tier.Application.Models;
using N_Tier.Application.Models.RegionModels;
using N_Tier.DataAccess.Repositories;
using N_Tier.Shared.Services;

namespace N_Tier.Application.Services.Impl
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;

        public RegionService(IClaimService claimService, IMapper mapper, IRegionRepository regionRepository)
        {
            _claimService = claimService;
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        public async Task<CreateRegionResponseModel> CreateAsync(CreateRegionModel createCategoryModel, CancellationToken cancellationToken = default)
        {
            var region = _mapper.Map<Region>(createCategoryModel);

            return new CreateRegionResponseModel
            {
                Id = (await _regionRepository.AddAsync(region)).Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var region = await _regionRepository.GetFirstAsync(c => c.Id == id);

            return new BaseResponseModel
            {
                Id = (await _regionRepository.DeleteAsync(region)).Id
            };
        }



        public List<RegionResponseModel> GetAllAsyncWithQuerable()
        {
            var regions = _regionRepository.GetAll();
            var result = regions.ToList();
            var result1 = _mapper.Map<List<RegionResponseModel>>(result);

            return result1;
        }

        public async Task<UpdateRegionResponseModel> UpdateAsync(Guid id, UpdateRegionModel updateCategoryModel, CancellationToken cancellationToken = default)
        {
            var category = await _regionRepository.GetFirstAsync(c => c.Id == id);
            _mapper.Map<Region>(updateCategoryModel);

            return new UpdateRegionResponseModel
            {
                Id = (await _regionRepository.UpdateAsync(category)).Id
            };
        }
    }
}
