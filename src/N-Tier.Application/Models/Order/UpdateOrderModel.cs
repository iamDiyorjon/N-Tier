namespace N_Tier.Application.Models.Order
{
    public class UpdateOrderModel
    {
        public Guid CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
    }
    public class UpdateOrderResponseModel : BaseResponseModel { }
}
