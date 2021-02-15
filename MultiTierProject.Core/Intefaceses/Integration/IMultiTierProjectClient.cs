using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiTierProject.Core.Intefaceses.Integration
{
    public interface IMultiTierProjectClient<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        bool Remove(int id);
    }
}
