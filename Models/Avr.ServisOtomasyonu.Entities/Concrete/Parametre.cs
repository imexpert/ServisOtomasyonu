using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Entities.Concrete
{
    public class Parametre : LightEntity
    {
        public long FirmaId { get; set; }
        public int? AnaGrupKod { get; set; }
        public string GrupKod { get; set; }
        public int Kod { get; set; }
        public string Aciklama { get; set; }
        public string Detay1 { get; set; }
        public string Detay2 { get; set; }
        public Firma Firma { get; set; }
    }
}
