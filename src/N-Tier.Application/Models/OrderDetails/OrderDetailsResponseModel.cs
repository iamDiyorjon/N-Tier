using System;

namespace N_Tier.Application.Models.ModelsByS.OrderDetails
{
    public class OrderDetailsResponseModel : BaseResponseModel
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
