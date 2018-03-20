using System.Collections.Generic;
using System.Threading.Tasks;
using Dp.Models.Database;

namespace Dp.Repository.DAL
{
    public interface IRepository<TEntity> where TEntity : class, IModelBase
    {
        Task<int> CreateAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetActiveAsync();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetDeletedAsync();
        Task<IEnumerable<TEntity>> GetInactiveAsync();
        Task<IEnumerable<TEntity>> GetNotDeletedAsync();
        Task UpdateAsync(TEntity entity);
    }
}