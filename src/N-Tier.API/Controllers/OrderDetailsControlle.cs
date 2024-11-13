using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ModelsByS.OrderDetails;
using N_Tier.Application.Services.ServicesByS;
using System;
using System.Threading.Tasks;

namespace N_Tier.API.Controllers.ControllerByS
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateOrderDetailsModel createOrderDetailsModel)
        {
            return Ok(ApiResult<CreateOrderDetailsResponseModel>.Success(
                await _orderDetailsService.CreateAsync(createOrderDetailsModel)));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateOrderDetailsModel updateOrderDetailsModel)
        {
            return Ok(ApiResult<UpdateOrderDetailsResponseModel>.Success(
                await _orderDetailsService.UpdateAsync(id, updateOrderDetailsModel)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            return Ok(ApiResult<BaseResponseModel>.Success(await _orderDetailsService.DeleteAsync(id)));
        }

        [HttpGet("{orderId:guid}")]
        public async Task<IActionResult> GetAllByOrderIdAsync(Guid orderId)
        {
            return Ok(ApiResult<IEnumerable<OrderDetailsResponseModel>>.Success(
                await _orderDetailsService.GetAllByOrderIdAsync(orderId)));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(ApiResult<IEnumerable<OrderDetailsResponseModel>>.Success(
                await _orderDetailsService.GetAllAsync()));
        }
    }
}
