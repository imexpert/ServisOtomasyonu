using AutoMapper;
using Avr.ServisOtomasyonu.DataTransferObject.Musteri;
using Avr.ServisOtomasyonu.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Api.Infrastructure.AutoMapperConfigurations
{
    public class MusteriProfile : Profile
    {
        public MusteriProfile()
        {
            // Mapping properties from Customer to CustomerModel  
            CreateMap<Musteri, MusteriModel>();
            CreateMap<MusteriModel, Musteri>();
        }
    }
}
