using System;
using System.Collections.Generic;
using System.Text;

namespace Avr.ServisOtomasyonu.DataTransferObject.MusteriAdres
{
    public class MusteriAdresModel
    {
        public long MusteriId { get; set; } // MusteriId
        public long SehirId { get; set; } // SehirId
        public long IlceId { get; set; } // IlceId
        public long SemtId { get; set; } // SemtId
        public string CariKod { get; set; } // CariKod (length: 50)
        public string AcikAdres { get; set; } // AcikAdres (length: 200)
        public string YetkiliAdSoyad { get; set; } // YetkiliAdSoyad (length: 100)
        public int YetkiliGörevKod { get; set; } // YetkiliGörevi (length: 50)
        public string YetkiliCepTel { get; set; } // YetkiliCepTel (length: 15)
        public string YetkiliTel { get; set; } // YetkiliTel (length: 15)
        public string YetkiliDahili { get; set; } // YetkiliDahili (length: 50)
        public string YetkiliFaks { get; set; } // YetkiliFaks (length: 50)
        public string YetkiliEPosta { get; set; } // YetkiliEPosta (length: 50)
        public string AdresDetay { get; set; } // AdresDetay (length: 200)
    }
}
