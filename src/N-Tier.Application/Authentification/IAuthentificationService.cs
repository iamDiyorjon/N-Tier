using EasyJob.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Authentification
{
    public interface IAuthentificationService
    {
        Task<TokenDto> LogInAsync(AuthenticationDto authenticationDto);
        Task<TokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
    }
}
