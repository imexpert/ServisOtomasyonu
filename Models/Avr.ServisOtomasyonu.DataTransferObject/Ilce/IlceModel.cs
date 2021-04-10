using System;
using System.Collections.Generic;
using System.Text;

namespace Avr.ServisOtomasyonu.DataTransferObject.Ilce
{
    public class IlceModel
    {
        public long Id { get; set; }
        public long SehirId { get; set; }
        public string IlceAdi { get; set; }
    }
}
