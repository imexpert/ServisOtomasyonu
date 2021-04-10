using System;
using System.Collections.Generic;
using System.Text;

namespace Avr.ServisOtomasyonu.DataTransferObject.Musteri
{
    public class MusteriModel
    {
        public long FirmaId { get; set; } // FirmaId
        public string MusteriUnvan { get; set; } // MusteriUnvan (length: 500)
        public int SektorKodu { get; set; } // SektorKodu
    }
}
