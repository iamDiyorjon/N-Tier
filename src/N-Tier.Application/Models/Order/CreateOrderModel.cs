using N_Tier.Core.Entities;

namespace N_Tier.Application.Models.Order
{
    public class CreateOrderModel
    {
        public Guid CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
        public List<CreateOrderDetailsModel> OrderDetails { get; set; }
    }
    public class CreateOrderResponseModel : BaseResponseModel { }
}
