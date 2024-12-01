using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities
{
    public class Order : BaseEntity, IAuditedEntity
    {
        public DateTime OrderDate { get; set; }
        public List<OrderDetails> OrderDetails { get; } = new List<OrderDetails>();
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
