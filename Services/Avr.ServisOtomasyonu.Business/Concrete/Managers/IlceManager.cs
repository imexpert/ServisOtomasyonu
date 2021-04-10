using AutoMapper;
using Avr.Core.Results;
using Avr.Core.Utilities.Extensions;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataAccess.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Ilce;
using Avr.ServisOtomasyonu.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Business.Concrete.Managers
{
    public class IlceManager : IIlceService
    {
        IIlceDal _dal;

        public IlceManager(IIlceDal dal)
        {
            _dal = dal;
        }

        public async Task<AjaxResult<List<IlceModel>>> GetirIlceAsync(int sehirId)
        {
            AjaxResult<List<IlceModel>> result = new AjaxResult<List<IlceModel>>();
            IEnumerable<Ilce> list = null;
            List<IlceModel> listModel = new List<IlceModel>();

            list = await _dal.GetirAsync(s => s.SehirId == sehirId);

            foreach (var item in list)
            {
                IlceModel p = new IlceModel();
                item.MapTo<Ilce, IlceModel>(p);
                listModel.Add(p);
            }

            result.data = listModel;
            return result;
        }
    }
}
