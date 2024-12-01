using N_Tier.Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Domain.Models.Entities.Info
{
    public class District : BaseEntity, IAuditedEntity
    {

        [Column("short_name")]
        [StringLength(50)]
        public string ShortName { get; set; } = null!;

        [Column("full_name")]
        [StringLength(50)]
        public string FullName { get; set; } = null!;

        [Column("region_id")]
        public Guid RegionId { get; set; }

        [ForeignKey("RegionId")]
        [InverseProperty("Districts")]
        public virtual Region Region { get; set; } = null!;

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}