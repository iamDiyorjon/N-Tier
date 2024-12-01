using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.DataAccess.Authentification
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int KeySize = 32;
        private const int IterationsCount = 1000;

        public string Encrypt(string password, string salt)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
           password: password,
           salt: Encoding.UTF8.GetBytes(salt),
           iterations: IterationsCount,
           hashAlgorithm: HashAlgorithmName.SHA256))
            {
                return Convert.ToBase64String(algorithm.GetBytes(KeySize));
            }
        }

        public bool VerifyPassword(string hash, string password, string salt)
        {
             return Encrypt(password, salt).SequenceEqual(hash);
        }
    }
}
