using EasyJob.Application.DataTransferObjects;
using EasyJob.Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using N_Tier.Application.Exceptions;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Authentification;
using N_Tier.DataAccess.Persistence;
using N_Tier.DataAccess.Repositories;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace N_Tier.Application.Authentification
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IUserRepository userRepository;
        private readonly IJwtTokenHandler jwtTokenHandler;
        private readonly IPasswordHasher passwordHasher;
        private readonly JwtOption jwtOption;

        private User _user;
        private readonly DatabaseContext _databaseContext;

        public AuthentificationService(
            IOptions<JwtOption> options,
            IJwtTokenHandler jwtTokenHandler,
            IPasswordHasher passwordHasher,
            IUserRepository userRepository)
        {
            this.jwtOption = options.Value;
            this.passwordHasher = passwordHasher;
            this.userRepository = userRepository;
            this.jwtTokenHandler = jwtTokenHandler;
        }

        public async Task<TokenDto> LogInAsync(AuthenticationDto authenticationDto)
        {
            _user = await userRepository.GetFirstAsync(a => a.Username == authenticationDto.username);

            //_user = await userRepository.SelectByIdWithDetailsAsync(
            //   expression: _user => _user.Username == authenticationDto.username,
            //   includes: Array.Empty<string>());

            if (_user is null)
            {
                throw new NotFoundException("User with this credentials not found");
            }

            if (!passwordHasher.VerifyPassword(
                _user.PassWordHash,
                authenticationDto.password,
                _user.Salt))
            {
                throw new NotFoundException("Username or password is not valid");
            }

            string refreshToken = jwtTokenHandler.GenerateRefreshToken();

            _user.UpdateRefreshToken(refreshToken);

            var updateUser = await userRepository.UpdateAsync(_user);

            var accessToken = jwtTokenHandler.GenerateAccessToken(updateUser);

            var entity = new TokenDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                RefreshToken = _user.RefreshToken,
                ExpireDate = accessToken.ValidTo
            };
            
            return entity;
        }

        public async Task<TokenDto> RefreshTokenAsync(
        RefreshTokenDto refreshTokenDto)
        {
            var claimsPrincipal = GetPrincipalFromExpiredToken(
                refreshTokenDto.accessToken);

            var userId = claimsPrincipal.FindFirstValue(CustomClaimNames.Id);

            var storageUser = await this.userRepository
                .SelectById(Guid.Parse(userId));

            if (!storageUser.RefreshToken.Equals(refreshTokenDto.refreshToken))
            {
                throw new ValidationException("Refresh token is not valid");
            }

            if (storageUser.RefreshTokenExpireDate <= DateTime.UtcNow)
            {
                throw new ValidationException("Refresh token has already been expired");
            }

            var newAccessToken = this.jwtTokenHandler
                .GenerateAccessToken(storageUser);

            return new TokenDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = refreshTokenDto.refreshToken,
                ExpireDate = newAccessToken.ValidTo
            };
            //(
            //    accessToken: new JwtSecurityTokenHandler()
            //        .WriteToken(newAccessToken),

            //    refreshToken: storageUser.RefreshToken,
            //    expireDate: newAccessToken.ValidTo);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(
            string accessToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = this.jwtOption.Audince,
                ValidateIssuer = true,
                ValidIssuer = this.jwtOption.Issuer,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,

                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(this.jwtOption.SecretKey))
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = tokenHandler.ValidateToken(
                token: accessToken,
                validationParameters: tokenValidationParameters,
                validatedToken: out SecurityToken securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new ValidationException("Invalid token");
            }

            return principal;
        }
    }
}
