using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.RegionModels
{
    public class UpdateRegionModel
    {
        public string Name { get; set; } = null!;
    }

    public class UpdateRegionResponseModel : BaseResponseModel { }
}
