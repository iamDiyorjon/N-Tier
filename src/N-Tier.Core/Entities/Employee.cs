using N_Tier.Core.Common;
using N_Tier.Core.Enums;

namespace N_Tier.Core.Entities
{
    public class Employee : BaseEntity 
    {
        public Person Person { get; set; }
        public Guid PersonID { get; set; }
        public Position Position { get; set; }
        public decimal Salary { get; set; }
    }
}
