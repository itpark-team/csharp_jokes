using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestWebApplication.Tools
{
    public class AuthOptions
    {

        public const string ISSUER = "JokesServer"; // издатель токена
        public const string AUDIENCE = "JokesClient"; // потребитель токена
        const string KEY = "superduper_secretkey!1234";   // ключ для шифрации
        public const int LIFETIME = 10; // время жизни токена - 10 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
