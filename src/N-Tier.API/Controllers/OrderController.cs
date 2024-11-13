using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ModelsByS.Order;
using N_Tier.Application.Services.ServicesByS;
using System;
using System.Threading.Tasks;

namespace N_Tier.API.Controllers.ControllerByS
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrderModel createOrderModel)
        {
            return Ok(ApiResult<CreateOrderResponseModel>.Success(
                await _orderService.CreateAsync(createOrderModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateOrderModel updateOrderModel)
        {
            return Ok(ApiResult<UpdateOrderResponseModel>.Success(
                await _orderService.UpdateAsync(id, updateOrderModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponseModel>.Success(await _orderService.DeleteAsync(id)));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            return Ok(ApiResult<OrderResponseModel>.Success(await _orderService.GetByIdAsync(id)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(ApiResult<IEnumerable<OrderResponseModel>>.Success(await _orderService.GetAllAsync()));
        }
    }
}
