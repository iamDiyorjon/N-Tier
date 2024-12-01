using N_Tier.Application.Models.User1;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Authentification;

namespace N_Tier.Application.Services.Impl
{
    public class UserFactory : IUserFactory
    {
        private readonly IPasswordHasher passwordHasher;

        public UserFactory(IPasswordHasher passwordHasher)
        {
            this.passwordHasher = passwordHasher;
        }
        public User MapToUser(UserForCreationDto userDto)
        {
            string salt = Guid.NewGuid().ToString();
            return new User
            {
                Salt = salt,
                Username = userDto.UserName,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber,
                PassWordHash = passwordHasher.Encrypt(userDto.Password, salt),
            };
        }
    }
}


