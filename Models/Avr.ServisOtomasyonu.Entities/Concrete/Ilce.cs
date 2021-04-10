using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Entities.Concrete
{
    public class Ilce : LightEntity
    {
        public long SehirId { get; set; } // SehirId
        public string IlceAdi { get; set; } // IlceAdi (length: 100)
        public Sehir Sehir { get; set; }
    }
}
