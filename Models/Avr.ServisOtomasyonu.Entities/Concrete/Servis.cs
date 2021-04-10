using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Entities.Concrete
{
    public class Servis : Entity
    {
        public long CihazId { get; set; } // CihazId
        public string ArizaBildirenIsim { get; set; } // ArizaBildirenIsim (length: 100)
        public string ArizaBildirenTelefon { get; set; } // ArizaBildirenTelefon (length: 15)
        public DateTime? ArizaTarihi { get; set; } // ArizaTarihi
        public int ServisAcilisKodu { get; set; } // ServisAcilisKodu
        public string ServisAcilisAciklama { get; set; } // ServisAcilisAciklama (length: 200)
        public DateTime ServisAcilisTarihi { get; set; } // ServisAcilisTarihi
        public int? AtananTeknisyenId { get; set; } // AtananTeknisyenId
        public DateTime? AtanmaTarihi { get; set; } // AtanmaTarihi
        public int? ServisKapanisKodu { get; set; } // ServisKapanisKodu
        public string ServisKapanisAciklama { get; set; } // ServisKapanisAciklama (length: 200)
        public DateTime? ServisKapanisTarihi { get; set; } // ServisKapanisTarihi
        public int? ServisDurumKodu { get; set; } // ServisDurumKodu
        public int? IptalKodu { get; set; } // IptalKodu
        public string IptalAciklama { get; set; } // IptalAciklama (length: 200)
        public string IptalEdenKullanici { get; set; } // IptalEdenKullanici (length: 100)
        public string IptalEdenKullaniciTelefon { get; set; } // IptalEdenKullaniciTelefon (length: 15)
        public int? TespitKodu { get; set; } // TespitKodu
        public string TespitAciklama { get; set; } // TespitAciklama (length: 200)
        public string TespitYapanKullanici { get; set; } // TespitYapanKullanici (length: 100)
        public int? RenkliSayacSayi { get; set; } // RenkliSayacSayi
        public int? SiyahBeyazSayacSayi { get; set; } // SiyahBeyazSayacSayi
        public int? TonerTipKodu { get; set; } // TonerTipKodu
        public int? SariTonerAdet { get; set; } // SariTonerAdet
        public int? MaviTonerAdet { get; set; } // MaviTonerAdet
        public int? KirmiziTonerAdet { get; set; } // KirmiziTonerAdet
        public int? SiyahTonerAdet { get; set; } // SiyahTonerAdet
        public bool? Dr { get; set; } // Dr
        public bool? Dv { get; set; } // Dv
        public bool? Bc { get; set; } // Bc
        public bool? Fs { get; set; } // Fs
        public bool? Pa { get; set; } // Pa
        public bool? Bk { get; set; } // Bk
        public bool? Ak { get; set; } // Ak
        public Cihaz Cihaz { get; set; }
    }
}
