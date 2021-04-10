using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Entities.Concrete
{
    public class CihazModel : LightEntity
    {
        public long CihazMarkaId { get; set; }
        public string ModelAdi { get; set; }
        public int FotokopiKod { get; set; }
        public int PrinterKod { get; set; }
        public int FaksKod { get; set; }
        public int ScannerKod { get; set; }
        public int TipKod { get; set; }
        public int RenkKod { get; set; }
        public int HizKod { get; set; }
        public int NetworkKod { get; set; }
        public CihazMarka CihazMarka { get; set; }
    }
}
