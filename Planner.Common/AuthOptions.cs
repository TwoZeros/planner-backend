using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Planner.Common
{
    public class AuthOptions
    {
        public const string Issuer = "NightDev Production"; // издатель токена
        public const string Audience = "BlackList CRM"; // потребитель токена
        const string Key = "mysupersecret_BlackList!123";   // ключ для шифрации
        public const int Lifetime = 1440; // время жизни токена - 24 часа
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
