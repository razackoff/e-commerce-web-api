using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace Market.Auth.Common
{
    public class AuthOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }    
        public string SecretKey { get; set; }
        public int TokenLifeTime { get; set; } //secs
        public SymmetricSecurityKey GetSymmetricSecuriteKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
        }
    }
}