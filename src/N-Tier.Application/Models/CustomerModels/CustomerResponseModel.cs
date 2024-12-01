using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.CustomerModels
{
    public class CustomerResponseModel : BaseResponseModel
    {
        public Guid PersonId { get; set; }
    }
}
