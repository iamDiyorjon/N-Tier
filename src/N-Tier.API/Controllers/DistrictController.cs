using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models.RegionModels;
using N_Tier.Application.Models;
using N_Tier.Application.Services;
using N_Tier.Application.Services.Impl;
using N_Tier.Application.Models.DistrictModels;

namespace N_Tier.API.Controllers
{
    public class DistrictController : ApiController
    {
        private readonly IDistrictService districtService; 
        public DistrictController(IDistrictService districtService)
        {
            this.districtService = districtService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateDistrictModel model)
        {
            return Ok(ApiResult<CreateDistrictResponseModel>.Success(
               await districtService.CreateAsync(model)));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateDistrictModel model)
        {
            return Ok(ApiResult<UpdateDistrictResponseModel>.Success(
                await districtService.UpdateAsync(id, model)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponseModel>.Success(
                await districtService.DeleteAsync(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(ApiResult<List<DistrictResponseModel>>.Success(
                 districtService.GetAllAsyncWithQuerable()));
        }
    }
}
