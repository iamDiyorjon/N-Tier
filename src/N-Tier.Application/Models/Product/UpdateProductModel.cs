using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.ModelsByS.Product
{
    public class UpdateProductModel
    {
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsDone { get; set; }
    }
    public class UpdateCategoryResponseModel : BaseResponseModel { }
}
