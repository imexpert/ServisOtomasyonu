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
    public class KullaniciDal : EntityRepositoryBase<Kullanici, ServisOtomasyonuContext>, IKullaniciDal
    {
        ServisOtomasyonuContext _context;
        public KullaniciDal(ServisOtomasyonuContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
