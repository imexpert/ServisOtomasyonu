using AutoMapper;
using Avr.Core.Results;
using Avr.Core.Utilities.Extensions;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataAccess.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Musteri;
using Avr.ServisOtomasyonu.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Business.Concrete.Managers
{
    public class MusteriManager : IMusteriService
    {
        IMusteriDal _dal;
        IMapper _mapper;

        public MusteriManager(IMusteriDal dal, IMapper mapper)
        {
            _dal = dal;
            _mapper = mapper;
        }

        public async Task<AjaxResult<MusteriModel>> MusteriKaydetAsync(MusteriModel model)
        {
            AjaxResult<MusteriModel> result = new AjaxResult<MusteriModel>();
            Musteri musteri = _mapper.Map<Musteri>(model);
            musteri.FirmaId = UserInformation.FirmaId;
            musteri = await _dal.EkleAsync(musteri);
            result.data = model;
            return result;
        }
    }
}
