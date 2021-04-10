using Avr.Core.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Avr.Core.DataAccess.DataAccess.EntityFrameworkCore
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> GetirAsQueryable(Expression<Func<T, bool>> filter = null);
        Task<T> OkuAsync(Expression<Func<T, bool>> filter = null, bool asNoTracking = true);
        Task<IEnumerable<T>> GetirAsync(Expression<Func<T, bool>> filter = null, bool asNoTracking = true);
        Task<T> EkleAsync(T entity);
        Task<T> GuncelleAsync(T entity);
        void SilAsync(T entity);
    }
}
