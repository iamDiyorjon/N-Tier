using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ModelsByS.Category;
using N_Tier.Application.Models.ModelsByS.Product;
using N_Tier.Application.Services.ServicesByS;
using N_Tier.Application.Models.ModelsByS.Product;

namespace N_Tier.API.Controllers.ControllerByS
{
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService _productService)
        {
            {
                _productService = _productService;
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductModel createProductModel)
        {
            return Ok(ApiResult<ProductResponseModel>.Success(
                await _productService.CreateAsync(createProductModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateProductModel updateProductModel)
        {
            return Ok(ApiResult<UpdateProductModel>.Success(
                await _productService.UpdateAsync(id, updateProductModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponseModel>.Success(await _productService.DeleteAsync(id)));
        }
    }
}
