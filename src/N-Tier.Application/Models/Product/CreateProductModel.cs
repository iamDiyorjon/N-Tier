using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.ModelsByS.Product
{
    public class CreateProductModel
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
    public class CreateProdyctResponseModel : BaseResponseModel { }
}
