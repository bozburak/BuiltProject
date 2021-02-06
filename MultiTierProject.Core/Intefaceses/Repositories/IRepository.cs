using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiTierProject.Core.Intefaceses.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync(int id);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync();
        Task<TEntity> AddRangeAsync();
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);
        TEntity Update(TEntity entity);
    }
}
