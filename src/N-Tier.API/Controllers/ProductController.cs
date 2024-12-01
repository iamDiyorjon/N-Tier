using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ProductModels;
using N_Tier.Application.Services;
using N_Tier.Core.Entities;

namespace N_Tier.API.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductModel createProductModel)
        {
            return Ok(ApiResult<CreateProductResponseModel>.Success(
                await _productService.CreateAsync(createProductModel)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _productService.DeleteAsync(id);
            return Ok(ApiResult<BaseResponseModel>.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllwithQuerable()
        {
            var products = await _productService.GetAllAsyncWithQuerable();
            return Ok(ApiResult<List<Product>>.Success(products));
        }
    }
}
