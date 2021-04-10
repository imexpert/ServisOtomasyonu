using AutoMapper;
using Avr.ServisOtomasyonu.DataTransferObject.Musteri;
using Avr.ServisOtomasyonu.DataTransferObject.MusteriAdres;
using Avr.ServisOtomasyonu.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Api.Infrastructure.AutoMapperConfigurations
{
    public class MusteriAdresProfile : Profile
    {
        public MusteriAdresProfile()
        {
            // Mapping properties from Customer to CustomerModel  
            CreateMap<MusteriAdres, MusteriAdresModel>();
            CreateMap<MusteriAdresModel, MusteriAdres>();
        }
    }
}
