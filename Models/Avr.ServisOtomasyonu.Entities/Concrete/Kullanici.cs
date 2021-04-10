using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avr.ServisOtomasyonu.Entities.Concrete
{
    public class Kullanici : Entity
    {
        public long FirmaId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string EPosta { get; set; }
        public string Telefon { get; set; }
        public string Gorev { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
        public int Durum { get; set; }
        public Firma Firma { get; set; }
    }
}
