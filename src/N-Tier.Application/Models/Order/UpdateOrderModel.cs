using System;

namespace N_Tier.Application.Models.ModelsByS.Order
{
    public class UpdateOrderModel
    {
        public Guid OrderId { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class UpdateOrderResponseModel : BaseResponseModel { }
}
