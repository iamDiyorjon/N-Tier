﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Models.Customer
{
    public class CustomerResponseModel : BaseResponseModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
