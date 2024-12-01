using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.User1;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers
{
    [Controller]

    public class UserController1 : ApiController
    {
        private readonly IUser1Service userService1;

        public UserController1(IUser1Service userService1)
        {
            this.userService1 = userService1;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser(UserForCreationDto userDto)
        {
            return Ok(ApiResult<UserForCreationResponseDto>.Success(await userService1.CreateUser(userDto)));
        }
    }
}
