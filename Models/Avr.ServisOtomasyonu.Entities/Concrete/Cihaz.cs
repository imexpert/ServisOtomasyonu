using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Entities.Concrete
{
    public class Cihaz : Entity
    {
        public long MusteriAdresId { get; set; }
        public long CihazMarkaId { get; set; }
        public long CihazTipId { get; set; }
        public long CihazModelId { get; set; }
        public string SeriNo { get; set; }
        public DateTime MontajTarihi { get; set; }
        public int BakimPeriyodId { get; set; }
        public int DurumKod { get; set; }
        public MusteriAdres MusteriAdres { get; set; }
        public CihazMarka CihazMarka { get; set; }
        public CihazTip CihazTip { get; set; }
        public CihazModel CihazModel { get; set; }
    }
}
