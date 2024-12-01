using N_Tier.Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Domain.Models.Entities.Info
{
    [Table("info_region")]
    public class Region : BaseEntity, IAuditedEntity
    {
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [InverseProperty("Region")]
        public virtual ICollection<District> Districts { get; set; } = new List<District>();
        public string? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}
