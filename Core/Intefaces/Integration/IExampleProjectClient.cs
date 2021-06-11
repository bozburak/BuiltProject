using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Intefaces.Integration
{
    public interface IIntegrationProjectClient<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        bool Remove(int id);
    }
}
