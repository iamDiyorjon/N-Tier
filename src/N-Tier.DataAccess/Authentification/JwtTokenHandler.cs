using EasyJob.Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using N_Tier.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.DataAccess.Authentification
{
    public class JwtTokenHandler : IJwtTokenHandler
    {
        private readonly JwtOption jwtOption;

        public JwtTokenHandler(IOptions<JwtOption>options)
        {
            this.jwtOption = options.Value;
        }
        public JwtSecurityToken GenerateAccessToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(CustomClaimNames.Id, user.Id.ToString()),
                new Claim(CustomClaimNames.Username, user.Username)
            };

            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this.jwtOption.SecretKey));


            var token = new JwtSecurityToken(
                issuer: this.jwtOption.Issuer,
                audience: this.jwtOption.Audince,
                expires: DateTime.UtcNow.AddMinutes(this.jwtOption.ExpirationMinutes),
                claims: claims,
                signingCredentials: new SigningCredentials(
                    key: authSigningKey,
                    algorithm: SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        public string GenerateRefreshToken()
        {
            byte[] bytes = new byte[64];

            using var randomGenerator =
                RandomNumberGenerator.Create();

            randomGenerator.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
