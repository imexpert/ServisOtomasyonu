using System;
using System.Collections.Generic;
using System.Text;

namespace Avr.Core.Utilities.Exceptions
{
    public class ServisOtomasyonuException : Exception
    {
        public ServisOtomasyonuException()
        { }

        public ServisOtomasyonuException(string message)
            : base(message)
        { }

        public ServisOtomasyonuException(string message, Exception innerException)
            : base(message, innerException)
        { }

    }
}
