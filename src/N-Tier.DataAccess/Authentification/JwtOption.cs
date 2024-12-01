namespace N_Tier.DataAccess.Authentification
{
    public class JwtOption
    {
        public string Issuer { get; set; }
        public string Audince { get; set; }
        public string SecretKey { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
