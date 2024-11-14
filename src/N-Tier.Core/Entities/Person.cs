using N_Tier.Core.Common;
using N_Tier.Core.Enums;

namespace N_Tier.Core.Entities
{
    public class Person : BaseEntity, IAuditedEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
