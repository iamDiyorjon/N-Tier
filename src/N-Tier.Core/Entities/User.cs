using N_Tier.Core.Common;

namespace N_Tier.Core.Entities
{
    public class User : BaseEntity
    {
        public const int DEFAULT_EXPIRE_DATE_IN_MINUTES = 1440;
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; } = null!;
        public string PassWordHash { get; set; }
        public string Salt { get; set; }
        public string? RefreshToken { get; private set; }
        public DateTime? RefreshTokenExpireDate { get; private set; }

        public void UpdateRefreshToken(string refreshtoken,
            int expireDateMinutes = DEFAULT_EXPIRE_DATE_IN_MINUTES)
        {
            RefreshToken = refreshtoken;
            RefreshTokenExpireDate = DateTime.UtcNow
                .AddMinutes(expireDateMinutes);
        }
    }
}
