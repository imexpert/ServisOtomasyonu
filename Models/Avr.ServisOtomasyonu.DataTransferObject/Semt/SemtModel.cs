using System;
using System.Collections.Generic;
using System.Text;

namespace Avr.ServisOtomasyonu.DataTransferObject.Semt
{
    public class SemtModel
    {
        public long Id { get; set; }
        public long IlceId { get; set; }
        public string SemtAdi { get; set; }
        public string BolgeAdi { get; set; }
        public string Aciklama
        {
            get
            {
                if (string.IsNullOrEmpty(BolgeAdi))
                {
                    return SemtAdi;
                }
                else
                {
                    return $"{BolgeAdi} - {SemtAdi}";
                }
            }
            set
            {

            }
        }
    }
}
