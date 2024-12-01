using N_Tier.Application.Models;
using N_Tier.Application.Models.Order;

namespace N_Tier.Application.Services
{
    public interface IOrderService
    {
        Task<CreateOrderResponseModel> CreateAsync(CreateOrderDetailsModel model,
          CancellationToken cancellation = default);
        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellation = default);
        //Task<IEnumerable<OrderResponseModel>> GetAllAsync();
        //Task<IEnumerable<OrderDetailsResponseModel>> GetByIdAsync(Guid id, CancellationToken cancellation = default);
        Task<UpdateOrderResponseModel> UpdateAsync(Guid id, UpdateOrderResponseModel updateOrderResponseModel, CancellationToken cancellation = default);
    }
}
