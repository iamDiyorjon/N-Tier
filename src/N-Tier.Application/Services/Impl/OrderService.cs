using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Order;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IOrderDetailsRepository orderDetailsRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task<CreateOrderResponseModel> CreateAsync(
            CreateOrderDetailsModel createOrderDetails,
            CancellationToken cancellation = default)
        {
            var order = _mapper.Map<OrderDetails>(createOrderDetails).Order;

            return new CreateOrderResponseModel
            {
                Id = (await _orderRepository.AddAsync(order)).Id
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(
            Guid id,
            CancellationToken cancellation = default)
        {
            var order = await _orderRepository.GetFirstAsync(o => o.Id == id);

            return new BaseResponseModel
            {
                Id = (await _orderRepository.DeleteAsync(order)).Id
            };
        }

        //public async Task<IEnumerable<OrderDetailsResponseModel>> GetByIdAsync(
        //    Guid id,
        //    CancellationToken cancellation = default)
        //{
        //    var order = await _orderRepository.GetFirstAsync(o => o.Id == id);
        //    if (order == null) throw new ResourceNotFoundException("There is no order with this id");
        //    var orderDetails = await _orderDetailsRepository.GetAllAsync(o => o.OrderId == order.Id);

        //    var orderDetailsResponse = _mapper.Map<List<OrderDetailsResponseModel>>(orderDetails);
        //    return orderDetailsResponse;
        //}

        public async Task<UpdateOrderResponseModel> UpdateAsync(Guid id,
            UpdateOrderResponseModel updateOrderResponseModel,
            CancellationToken cancellation = default)
        {
            var updateOrder = await _orderRepository.GetFirstAsync(o => o.Id == id);

            return new UpdateOrderResponseModel
            {
                Id = (await _orderRepository.UpdateAsync(updateOrder)).Id,
            };
        }


    }
}
