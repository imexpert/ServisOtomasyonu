using System;
using System.Collections.Generic;
using System.Text;

namespace Avr.ServisOtomasyonu.DataTransferObject.Arama
{
    public class AramaFilterModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string Unvan { get; set; }
    }
}
