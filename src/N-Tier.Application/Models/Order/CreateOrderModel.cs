using System;

namespace N_Tier.Application.Models.ModelsByS.Order
{
    public class CreateOrderModel
    {
        public string OrderName { get; set; }
        public Guid CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
    }

    public class CreateOrderResponseModel : BaseResponseModel { }
}
