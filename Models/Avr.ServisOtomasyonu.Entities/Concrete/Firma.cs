using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Entities.Concrete
{
    public class Firma : Entity
    {
        public string FirmaKodu { get; set; }
        public string FirmaUnvan { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public int KullaniciSayisi { get; set; }
        public int Durum { get; set; }
    }
}
