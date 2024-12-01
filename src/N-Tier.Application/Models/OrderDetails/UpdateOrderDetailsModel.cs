namespace N_Tier.Application.Models.OrderDetails
{
    public class UpdateOrderDetailsModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
