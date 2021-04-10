using Avr.Core.Results;
using Avr.ServisOtomasyonu.DataTransferObject.Kullanici;
using Avr.ServisOtomasyonu.DataTransferObject.Login;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Business.Abstract
{
    public interface IKullaniciService
    {
        Task<AjaxResult<KullaniciModel>> GirisAsync(LoginModel model);
    }
}
