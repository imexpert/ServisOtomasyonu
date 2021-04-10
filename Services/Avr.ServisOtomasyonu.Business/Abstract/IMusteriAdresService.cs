using Avr.Core.Results;
using Avr.ServisOtomasyonu.DataTransferObject.MusteriAdres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Business.Abstract
{
    public interface IMusteriAdresService
    {
        Task<AjaxResult<MusteriAdresModel>> MusteriAdresKaydetAsync(MusteriAdresModel model);
    }
}
