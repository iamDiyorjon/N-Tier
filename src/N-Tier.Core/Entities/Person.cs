using N_Tier.Core.Common;

namespace N_Tier.Core.Entities
{
    public class Person : BaseEntity, IAuditedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
