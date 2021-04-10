using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Entities.Concrete
{
    public class Musteri : Entity
    {
        public long FirmaId { get; set; } // FirmaId
        public string MusteriUnvan { get; set; } // MusteriUnvan (length: 500)
        public int SektorKodu { get; set; } // SektorKodu
        public Firma Firma { get; set; }
    }
}
