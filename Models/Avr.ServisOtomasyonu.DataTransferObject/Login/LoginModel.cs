using System;
using System.Collections.Generic;
using System.Text;

namespace Avr.ServisOtomasyonu.DataTransferObject.Login
{
    public class LoginModel
    {
        public string FirmaKodu { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
