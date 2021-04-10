using Avr.ServisOtomasyonu.Entities.Concrete;

namespace Avr.Core.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Kullanici kullanici);
    }
}
