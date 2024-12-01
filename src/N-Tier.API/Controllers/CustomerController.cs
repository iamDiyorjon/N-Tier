using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.CustomerModels;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCustomerModel createCustomerModel)
        {
            return Ok(ApiResult<CreateCustomerResponseModel>.Success(
                await _customerService.CreateAsync(createCustomerModel)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _customerService.DeleteAsync(id);
            return Ok(ApiResult<BaseResponseModel>.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllwithQuerable()
        {
            var customers = await _customerService.GetAllAsyncWithQuerable();
            return Ok(ApiResult<List<CustomerResponseModel>>.Success(customers));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateCustomerModel updateCustomerModel)
        {
            var customer = await _customerService.UpdateAsync(id, updateCustomerModel);

            return Ok(ApiResult<UpdateCustomerResponseModel>.Success(customer));
        }
    }
}
