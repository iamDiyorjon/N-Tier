using N_Tier.Core.Common;

namespace N_Tier.Core.Entities
{
    public class Order : BaseEntity, IAuditedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public virtual ICollection<Product> Books { get; set; } = new List<Product>();

        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
