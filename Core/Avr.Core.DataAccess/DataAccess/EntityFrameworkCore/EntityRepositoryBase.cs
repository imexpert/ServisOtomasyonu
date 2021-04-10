using Avr.Core.Auditing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Avr.Core.DataAccess.DataAccess.EntityFrameworkCore
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        private readonly TContext _context;
        public EntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetirAsQueryable(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return _context.Set<TEntity>().AsQueryable();
            }
            else
            {
                return _context.Set<TEntity>().Where(filter).AsQueryable();
            }
        }

        public async Task<TEntity> EkleAsync(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GuncelleAsync(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);

            addedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public void SilAsync(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public async Task<TEntity> OkuAsync(Expression<Func<TEntity, bool>> filter, bool asNoTracking = true)
        {
            if (asNoTracking)
                return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
            else
                return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<TEntity>> GetirAsync(Expression<Func<TEntity, bool>> filter = null, bool asNoTracking = true)
        {
            if (filter != null)
            {
                if (asNoTracking)
                    return await _context.Set<TEntity>().AsNoTracking().Where(filter).ToListAsync();
                else
                    return await _context.Set<TEntity>().Where(filter).ToListAsync();
            }
            else
            {
                if (asNoTracking)
                    return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
                else
                    return await _context.Set<TEntity>().ToListAsync();
            }
        }
    }
}
