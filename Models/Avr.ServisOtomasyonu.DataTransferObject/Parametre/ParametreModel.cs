using System;
using System.Collections.Generic;
using System.Text;

namespace Avr.ServisOtomasyonu.DataTransferObject.Parametre
{
    public class ParametreModel
    {
        public long FirmaId { get; set; }
        public int AnaGrupKod { get; set; }
        public string GrupKod { get; set; }
        public int Kod { get; set; }
        public string Aciklama { get; set; }
        public string Detay1 { get; set; }
        public string Detay2 { get; set; }
    }
}
