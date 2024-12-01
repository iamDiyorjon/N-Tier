using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Category;
using N_Tier.Application.Services;
using N_Tier.Core.Entities;

namespace N_Tier.API.Controllers
{
    [Authorize]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCategoryModel createCategoryModel)
        {
            return Ok(ApiResult<CreateCategoryResponseModel>.Success(
                await _categoryService.CreateaAsync(createCategoryModel)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Ok(ApiResult<BaseResponseModel>.Success(
                await _categoryService.DeleteAsync(id)));
        }

        [HttpGet]
        [EnableRateLimiting("fixed")]
        public async Task<IActionResult> GetAllWithQuery()
        {
            var result = await _categoryService.GetAllWithIQueryableAsync();

            return Ok(ApiResult<List<Category>>.Success(result));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateCategoryModel updateCategoryModel, CancellationToken cancellationToken = default)
        {
            var result = await _categoryService.UpdateAsync(id, updateCategoryModel);

            return Ok(ApiResult<UpdateCategoryResponseModel>.Success(result));
        }
    }
}
