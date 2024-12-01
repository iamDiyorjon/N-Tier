using N_Tier.Core.Enums;
using N_Tier.Core.Entities;

namespace N_Tier.Application.Models.CustomerModels
{
    public class CreateCustomerModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        //public static explicit operator CreateCustomerModel(Customer customer)
        //{
        //    return new CreateCustomerModel
        //    {
        //        Name = customer.Person.Name,
        //        Age = customer.Person.Age,
        //        Gender = customer.Person.Gender
        //    };
        //}
    }
    public class CreateCustomerResponseModel : BaseResponseModel { }
}
