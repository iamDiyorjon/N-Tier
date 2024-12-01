using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities
{
    public class OrderDetails : BaseEntity
    {
        
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public decimal Unit_price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }   
    }
}
