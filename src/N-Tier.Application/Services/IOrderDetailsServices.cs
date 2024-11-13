using N_Tier.Application.Models;
using N_Tier.Application.Models.ModelsByS.OrderDetails;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.ServicesByS
{
    public interface IOrderDetailsService
    {
        Task<CreateOrderDetailsResponseModel> CreateAsync(CreateOrderDetailsModel createOrderDetailsModel,
            CancellationToken cancellationToken = default);

        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<OrderDetailsResponseModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<IEnumerable<OrderDetailsResponseModel>> GetAllByOrderIdAsync(Guid orderId,
            CancellationToken cancellationToken = default);

        Task<UpdateOrderDetailsResponseModel> UpdateAsync(Guid id, UpdateOrderDetailsModel updateOrderDetailsModel,
            CancellationToken cancellationToken = default);
    }
}
