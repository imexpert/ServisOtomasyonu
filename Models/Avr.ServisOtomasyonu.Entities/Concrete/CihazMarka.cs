using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Entities.Concrete
{
    public class CihazMarka : LightEntity
    {
        public long CihazTipId { get; set; }
        public string MarkaAdi { get; set; }
        public CihazTip CihazTip { get; set; }
    }
}
