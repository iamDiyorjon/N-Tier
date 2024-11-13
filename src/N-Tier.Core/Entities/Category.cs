using N_Tier.Core.Common;

namespace N_Tier.Core.Entities
{
    public class Category : BaseEntity, IAuditedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Books { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}

