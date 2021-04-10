using System;
using System.Collections.Generic;
using System.Text;

namespace Avr.ServisOtomasyonu.DataTransferObject.Kullanici
{
    public class KullaniciModel
    {
        public long Id { get; set; }
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string AdSoyad
        {
            get
            {
                return Ad + " " + Soyad;
            }
            set { }
        }
        public string Token { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
    }
}
