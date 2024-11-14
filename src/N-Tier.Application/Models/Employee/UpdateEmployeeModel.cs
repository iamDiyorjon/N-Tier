namespace N_Tier.Application.Models.Employee
{
    public class UpdateEmployeeModel
    {
        public string Name
        {
            get; set;
        }
        public int Age
        {
            get; set;
        }
    }

    public class UpdateEmployeeResponseModel : BaseResponseModel { }
}
