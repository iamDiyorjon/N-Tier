using N_Tier.Application.Models;
using N_Tier.Application.Models.ModelsByS.Order;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.ServicesByS
{
    public interface IOrderService
    {
        Task<CreateOrderResponseModel> CreateAsync(CreateOrderModel createOrderModel,
            CancellationToken cancellationToken = default);

        Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IEnumerable<OrderResponseModel>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<OrderResponseModel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<UpdateOrderResponseModel> UpdateAsync(Guid id, UpdateOrderModel updateOrderModel,
            CancellationToken cancellationToken = default);
    }
}
