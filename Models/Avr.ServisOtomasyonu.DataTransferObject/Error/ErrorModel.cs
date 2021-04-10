using System;
using System.Collections.Generic;
using System.Text;

namespace Avr.ServisOtomasyonu.DataTransferObject.Error
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string DeveloperMessage { get; set; }
    }
}
