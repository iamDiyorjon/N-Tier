using N_Tier.Application.Models.ModelsByS.OrderDetails;
using System;
using System.Collections.Generic;

namespace N_Tier.Application.Models.ModelsByS.Order
{
    public class OrderResponseModel : BaseResponseModel
    {
        public string OrderName { get; set; }
        public Guid CustomerId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCompleted { get; set; }

        // OrderDetails bilan bog'liq mahsulotlar
        public List<OrderDetailsResponseModel> OrderDetails { get; set; } = new List<OrderDetailsResponseModel>();
    }
}
