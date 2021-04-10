using Avr.Core.Results;
using Avr.ServisOtomasyonu.DataTransferObject.Musteri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Business.Abstract
{
    public interface IMusteriService
    {
        Task<AjaxResult<MusteriModel>> MusteriKaydetAsync(MusteriModel model);
    }
}
