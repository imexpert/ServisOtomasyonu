using Avr.Core.Results;
using Avr.ServisOtomasyonu.Business.Abstract;
using Avr.ServisOtomasyonu.DataAccess.Concrete.EntityFrameworkCore;
using Avr.ServisOtomasyonu.DataTransferObject.Arama;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Business.Concrete.Managers
{
    public class AramaManager : IAramaService
    {
        ServisOtomasyonuContext _context;

        public AramaManager(ServisOtomasyonuContext context)
        {
            _context = context;
        }

        public async Task<AjaxResult<AramaModel>> AraAsync(AramaFilterModel filter)
        {
            AjaxResult<List<AramaModel>> result = new AjaxResult<List<AramaModel>>();

            var query = _context.Musteriler
                .AsQueryable()
                .Where(s => s.MusteriUnvan.Contains(filter.Unvan) || string.IsNullOrEmpty(filter.Unvan))
                .Select(s => new AramaModel()
                {
                    Unvan = s.MusteriUnvan
                });

            var sonuc = await query
               .OrderByDescending(s => s.Unvan)
               .Skip(filter.PageSize * filter.PageIndex)
               .Take(filter.PageSize)
               .ToListAsync();

            result.data = sonuc;
            throw new NotImplementedException();
        }
    }
}
