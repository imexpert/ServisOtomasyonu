using AutoMapper;
using Avr.Core.Results;
using Avr.Core.Utilities.Extensions;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataAccess.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.MusteriAdres;
using Avr.ServisOtomasyonu.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Business.Concrete.Managers
{
    public class MusteriAdresManager : IMusteriAdresService
    {
        IMusteriAdresDal _dal;
        IMapper _mapper;

        public MusteriAdresManager(IMusteriAdresDal dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public async Task<AjaxResult<MusteriAdresModel>> MusteriAdresKaydetAsync(MusteriAdresModel model)
        {
            AjaxResult<MusteriAdresModel> result = new AjaxResult<MusteriAdresModel>();
            MusteriAdres MusteriAdres = _mapper.Map<MusteriAdres>(model);
            MusteriAdres.MusteriId = 2;
            MusteriAdres = await _dal.EkleAsync(MusteriAdres);
            result.data = model;
            return result;
        }
    }
}
