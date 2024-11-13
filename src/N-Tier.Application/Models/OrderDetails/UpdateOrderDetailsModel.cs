using System;

namespace N_Tier.Application.Models.ModelsByS.OrderDetails
{
    public class UpdateOrderDetailsModel
    {
        public Guid OrderDetailsId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class UpdateOrderDetailsResponseModel : BaseResponseModel { }
}
