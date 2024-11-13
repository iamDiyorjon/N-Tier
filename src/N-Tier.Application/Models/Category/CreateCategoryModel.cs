using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.ModelsByS.Category
{
    public class CreateCategoryModel
    {
        public Guid ProdId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
    public class CreateCategoryResponseModel : BaseResponseModel { }
}
