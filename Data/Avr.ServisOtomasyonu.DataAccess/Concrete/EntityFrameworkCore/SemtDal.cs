using Avr.Core.DataAccess.DataAccess.EntityFrameworkCore;
using Avr.ServisOtomasyonu.DataAccess.Abstract;
using Avr.ServisOtomasyonu.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.DataAccess.Concrete.EntityFrameworkCore
{
    public class SemtDal : EntityRepositoryBase<Semt, ServisOtomasyonuContext>, ISemtDal
    {
        ServisOtomasyonuContext _context;
        public SemtDal(ServisOtomasyonuContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
