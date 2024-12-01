using EasyJob.Application.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Authentification;
using N_Tier.Application.Models;

namespace N_Tier.API.Controllers
{
    public class AuthentificationController : ApiController
    {
        private readonly IAuthentificationService authentificationService;

        public AuthentificationController(IAuthentificationService authentificationService)
        {
            this.authentificationService = authentificationService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(AuthenticationDto authenticationDto)
        {
            var tokendto = await authentificationService.LogInAsync(authenticationDto);

            return Ok(tokendto);
        }
    }
}
