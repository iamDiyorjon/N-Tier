using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.RegionModels;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers
{

    public class RegionController : ApiController
    {
        private readonly IRegionService regionService;

        public RegionController(IRegionService regionService)
        {
            this.regionService = regionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateRegionModel model)
        {
            return Ok(ApiResult<CreateRegionResponseModel>.Success(
               await regionService.CreateAsync(model)));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateRegionModel model)
        {
            return Ok(ApiResult<UpdateRegionResponseModel>.Success(
                await regionService.UpdateAsync(id, model)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponseModel>.Success(
                await regionService.DeleteAsync(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(ApiResult<List<RegionResponseModel>>.Success(
                 regionService.GetAllAsyncWithQuerable()));
        }
    }
}
