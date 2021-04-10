using Avr.Core.Results;
using Avr.ServisOtomasyonu.DataTransferObject.Kullanici;
using Avr.ServisOtomasyonu.DataTransferObject.Login;
using Avr.ServisOtomasyonu.DataTransferObject.Parametre;
using Avr.ServisOtomasyonu.DataTransferObject.Sehir;
using Avr.ServisOtomasyonu.DataTransferObject.Semt;
using Avr.ServisOtomasyonu.Entities.Concrete;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Business.Abstract
{
    public interface ISemtService
    {
        Task<AjaxResult<List<SemtModel>>> GetirSemtAsync(int ilceId);
    }
}
