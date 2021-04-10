using Avr.Core.DataAccess.DataAccess.EntityFrameworkCore;
using Avr.ServisOtomasyonu.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.DataAccess.Abstract
{
    public interface ISehirDal : IEntityRepository<Sehir>
    {

    }
}
