using N_Tier.Application.Models;
using N_Tier.Application.Models.DistrictModels;
using N_Tier.Application.Models.RegionModels;

namespace N_Tier.Application.Services
{
    public interface IDistrictService
    {
        public Task<CreateDistrictResponseModel> CreateAsync(CreateDistrictModel createCustomerModel, CancellationToken cancellationToken = default);
        public Task<UpdateDistrictResponseModel> UpdateAsync(Guid id, UpdateDistrictModel updateCustomerModel, CancellationToken cancellationToken = default);
        public Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        public List<DistrictResponseModel> GetAllAsyncWithQuerable();
    }
}
