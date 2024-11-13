using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.ModelsByS.Category
{
    public class CategoryResponseModel : BaseResponseModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsDone { get; set; }
    }
}
