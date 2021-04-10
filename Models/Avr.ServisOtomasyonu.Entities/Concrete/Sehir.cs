using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Entities.Concrete
{
    public class Sehir : LightEntity
    {
        public string SehirAdi { get; set; } // SehirAdi (length: 100)
    }
}
