using N_Tier.Application.Models;
using N_Tier.Application.Models.CustomerModels;
using N_Tier.Application.Models.RegionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services
{
    public interface IRegionService
    {
        public Task<CreateRegionResponseModel> CreateAsync(CreateRegionModel createCustomerModel, CancellationToken cancellationToken = default);
        public Task<UpdateRegionResponseModel> UpdateAsync(Guid id, UpdateRegionModel updateCustomerModel, CancellationToken cancellationToken = default);
        public Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        public List<RegionResponseModel> GetAllAsyncWithQuerable();
    }
}
