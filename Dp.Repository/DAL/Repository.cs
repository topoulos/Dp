using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Dp.Models.Database;
using Dp.Models.Security;

namespace Dp.Repository.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IModelBase
    {
        public async Task<int> CreateAsync(TEntity entity)
        {
            using (var db = new DpContext())
            {
                db.Set<TEntity>().Add(entity);
                await db.SaveChangesAsync();
                return entity.Id;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var db = new DpContext())
            {
                var entity = await db.TaskItems.FindAsync(id);
                entity.Deleted = true;
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetActiveAsync()
        {
            using (var db = new DpContext())
            {
                return await db.Set<TEntity>().Where(t => t.IsActive && !t.Deleted).ToListAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (var db = new DpContext())
            {
                return await db.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            using (var db = new DpContext())
            {
                return await db.Set<TEntity>().FindAsync(id);
            }
        }

        public async Task<IEnumerable<TEntity>> GetDeletedAsync()
        {
            using (var db = new DpContext())
            {
                return await db.Set<TEntity>().Where(t => t.Deleted).ToListAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetInactiveAsync()
        {
            using (var db = new DpContext())
            {
                return await db.Set<TEntity>().Where(t => !t.IsActive && !t.Deleted).ToListAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetNotDeletedAsync()
        {
            using (var db = new DpContext())
            {
                return await db.Set<TEntity>().Where(t => !t.Deleted).ToListAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (var db = new DpContext())
            {
                entity.ModifiedDateTime = DateTimeOffset.UtcNow;

                db.Set<TEntity>().Attach(entity);
                db.Entry(entity).State = EntityState.Modified;

                await db.SaveChangesAsync();
            }
        }
    }
}