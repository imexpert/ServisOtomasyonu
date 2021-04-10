using AutoMapper;
using Avr.Core.Results;
using Avr.Core.Utilities.Extensions;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataAccess.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Semt;
using Avr.ServisOtomasyonu.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Business.Concrete.Managers
{
    public class SemtManager : ISemtService
    {
        ISemtDal _dal;

        public SemtManager(ISemtDal dal)
        {
            _dal = dal;
        }

        public async Task<AjaxResult<List<SemtModel>>> GetirSemtAsync(int ilceId)
        {
            AjaxResult<List<SemtModel>> result = new AjaxResult<List<SemtModel>>();
            IEnumerable<Semt> list = null;
            List<SemtModel> listModel = new List<SemtModel>();

            list = await _dal.GetirAsync(s => s.IlceId == ilceId);

            foreach (var item in list)
            {
                SemtModel p = new SemtModel();
                item.MapTo<Semt, SemtModel>(p);
                listModel.Add(p);
            }

            result.data = listModel;
            return result;
        }
    }
}
