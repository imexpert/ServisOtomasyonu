using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Entities.Concrete
{
    public class Semt : LightEntity
    {
        public long IlceId { get; set; } // IlceId
        public string SemtAdi { get; set; } // SemtAdi (length: 100)
        public string BolgeAdi { get; set; } // SemtAdi (length: 100)
        public Ilce Ilce { get; set; }
    }
}
