using N_Tier.Core.Entities;
using N_Tier.Core.Enums;

namespace N_Tier.Application.Models.Employee
{
    public class CreateEmployeeModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Position Position { get; set; }
        public decimal Salary { get; set; }
    }

    public class CreateEmployeeResponseModel : BaseResponseModel { }
}
