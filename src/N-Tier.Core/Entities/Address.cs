using CRUD.Domain.Models.Entities.Info;
using N_Tier.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Core.Entities
{
    public class Address : BaseEntity
    {
        public Region Region { get; set; }
        public District District { get; set; }
        public string MFY { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
