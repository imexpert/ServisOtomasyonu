namespace Avr.Core.Security.Jwt
{
    public class TokenOptions
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
    }
}
