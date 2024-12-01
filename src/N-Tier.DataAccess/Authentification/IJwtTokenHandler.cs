using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using N_Tier.Core.Entities;

namespace N_Tier.DataAccess.Authentification
{
    public interface IJwtTokenHandler
    {
        JwtSecurityToken GenerateAccessToken(User user);
        string GenerateRefreshToken();
    }
}
