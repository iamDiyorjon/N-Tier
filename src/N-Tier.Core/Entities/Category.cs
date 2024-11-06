using N_Tier.Core.Common;

namespace N_Tier.Core.Entities
{
    public class Category : BaseEntity, IAuditedEntity
    {
        public string Name { get; set; }
        public  List<Product> Products { get;  } = new List<Product>();   
        public string? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
