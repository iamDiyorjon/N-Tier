namespace N_Tier.Application.Models.User1
{
    public class UserForCreationDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class UserForCreationResponseDto : BaseResponseModel { }
}
