using N_Tier.Core.Common;

namespace N_Tier.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Person Person { get; set; }
        public Guid PersonId { get; set; }

    }
}
