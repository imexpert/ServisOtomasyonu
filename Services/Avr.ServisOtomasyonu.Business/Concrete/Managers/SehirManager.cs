using AutoMapper;
using Avr.Core.Results;
using Avr.Core.Utilities.Extensions;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataAccess.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Sehir;
using Avr.ServisOtomasyonu.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Business.Concrete.Managers
{
    public class SehirManager : ISehirService
    {
        ISehirDal _dal;

        public SehirManager(ISehirDal dal)
        {
            _dal = dal;
        }

        public async Task<AjaxResult<List<SehirModel>>> GetirSehirAsync()
        {
            AjaxResult<List<SehirModel>> result = new AjaxResult<List<SehirModel>>();
            IEnumerable<Sehir> list = null;
            List<SehirModel> listModel = new List<SehirModel>();

            list = await _dal.GetirAsync();

            foreach (var item in list)
            {
                SehirModel p = new SehirModel();
                item.MapTo<Sehir, SehirModel>(p);
                listModel.Add(p);
            }

            result.data = listModel;
            return result;
        }
    }
}
