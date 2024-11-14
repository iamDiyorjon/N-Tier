using N_Tier.Core.Enums;

namespace N_Tier.Core.Entities
{
    public class Employee : Person
    {
        public Position Position { get; set; }
        public decimal Salary { get; set; }
    }
}
