namespace N_Tier.Application.Models.Employee
{
    public class CreateEmployeeModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class CreateEmployeeResponseModel : BaseResponseModel { }
}
