using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Entities.Concrete
{
    public class CihazTip : LightEntity
    {
        public string TipAdi { get; set; } // TipAdi (length: 100)
    }
}
