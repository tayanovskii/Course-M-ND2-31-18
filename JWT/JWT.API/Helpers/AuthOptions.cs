using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace JWT.API.Helpers
{
    public class AuthOptions
    {
        public const string Issuer = "MyAuthServer";
        public const string Audience = "http://localhost:59202/";
        const string Key = "secret_key777";
        public const int Lifetime = 3;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
