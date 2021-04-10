using Microsoft.IdentityModel.Tokens;

namespace Avr.Core.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
