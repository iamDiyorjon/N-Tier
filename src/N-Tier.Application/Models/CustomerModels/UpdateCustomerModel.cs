using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.CustomerModels
{
    public class UpdateCustomerModel
    {
        public Guid PersonId { get; set; }
    }
    public class UpdateCustomerResponseModel : BaseResponseModel { }
}
