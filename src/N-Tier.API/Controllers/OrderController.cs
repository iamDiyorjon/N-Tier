using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Order;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers
{

    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //[HttpGet("GetById")]

        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    return Ok(ApiResult<IEnumerable<OrderDetailsResponseModel>>.Success(
        //        await _orderService.GetByIdAsync(id)));
        //}

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrderDetailsModel createOrderModel)
        {
            return Ok(ApiResult<CreateOrderResponseModel>.Success(
               await _orderService.CreateAsync(createOrderModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateOrderResponseModel updateOrderModel)
        {
            return Ok(ApiResult<UpdateOrderResponseModel>.Success(
                await _orderService.UpdateAsync(id, updateOrderModel)));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponseModel>.Success(
                await _orderService.DeleteAsync(id)));
        }
    }
}
