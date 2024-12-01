using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.DataAccess.Authentification
{
    public interface IPasswordHasher
    {
        string Encrypt(string password, string salt);
        bool VerifyPassword(string hash, string password, string salt);
    }
}
