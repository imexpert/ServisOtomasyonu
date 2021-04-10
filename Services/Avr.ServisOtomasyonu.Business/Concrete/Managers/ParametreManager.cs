using AutoMapper;
using Avr.Core.Results;
using Avr.Core.Utilities.Extensions;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataAccess.Abstract;
using Avr.ServisOtomasyonu.DataTransferObject.Parametre;
using Avr.ServisOtomasyonu.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Business.Concrete.Managers
{
    public class ParametreManager : IParametreService
    {
        IParametreDal _dal;

        public ParametreManager(IParametreDal dal)
        {
            _dal = dal;
        }

        public async Task<AjaxResult<List<ParametreModel>>> GetirParametreAsync(int anaGrupKod, string grupKod)
        {
            AjaxResult<List<ParametreModel>> result = new AjaxResult<List<ParametreModel>>();
            IEnumerable<Parametre> list = null;
            List<ParametreModel> listModel = new List<ParametreModel>();

            if (anaGrupKod > 0)
            {
                list = await _dal.GetirAsync(s => s.AnaGrupKod == anaGrupKod && s.GrupKod == grupKod);
            }
            else
            {
                list = await _dal.GetirAsync(s => s.GrupKod == grupKod);
            }

            foreach (var item in list)
            {
                ParametreModel p = new ParametreModel();
                item.MapTo<Parametre, ParametreModel>(p);
                listModel.Add(p);
            }

            result.data = listModel;
            return result;
        }
    }
}
