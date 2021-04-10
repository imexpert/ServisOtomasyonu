using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Avr.Core.Security.Encryption;
using Avr.Core.Security.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Avr.ServisOtomasyonu.Entities.Concrete;

namespace Avr.Core.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration;
        public TokenOptions _tokenOptions;
        DateTime accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("JwtSettings").Get<TokenOptions>();
            accessTokenExpiration = DateTime.Now.AddDays(_tokenOptions.AccessTokenExpiration);
        }
        public AccessToken CreateToken(Kullanici kullanici)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.Secret);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            var jwt = CreateJwtSecurityToken(_tokenOptions, kullanici, signingCredentials);

            var jwtSecurityHandler = new JwtSecurityTokenHandler();

            var token = jwtSecurityHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = accessTokenExpiration
            };
        }

        public IEnumerable<Claim> SetClaim(Kullanici user)
        {
            var claims = new List<Claim>();

            claims.AddNameIdentifier(user.Id.ToString());

            claims.Add(new Claim("FirmaId", user.FirmaId.ToString()));
            claims.Add(new Claim("KullaniciId", user.Id.ToString()));
            claims.Add(new Claim("FirmaUnvan", user.Firma.FirmaUnvan.ToString()));
            claims.Add(new Claim("KullaniciAd", user.KullaniciAd.ToString()));
            claims.Add(new Claim("Gorev", user.Gorev));
            claims.Add(new Claim("AdSoyad", $"{user.Ad} {user.Soyad}"));
            claims.Add(new Claim("Ad", user.Ad));
            claims.Add(new Claim("Soyad", user.Soyad));
            claims.Add(new Claim("Email", user.EPosta ?? ""));
            claims.Add(new Claim("Telefon", user.Telefon ?? ""));

            return claims;
        }

        public JwtSecurityToken CreateJwtSecurityToken(
            TokenOptions tokenoption, 
            Kullanici user, 
            SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenoption.Issuer,
                audience: tokenoption.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaim(user),
                signingCredentials: signingCredentials
                );

            return jwt;
        }
    }
}
