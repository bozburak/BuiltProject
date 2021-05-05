using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Intefaceses.Services
{
    public interface IService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<TDto> GetByIdAsync(string id);
        Task<IEnumerable<TDto>> GetAllAsync();
        IEnumerable<TDto> Where(Expression<Func<TEntity, bool>> predicate);
        Task<TDto> AddAsync(TDto entity);
        Task<IEnumerable<TDto>> AddRangeAsync(IEnumerable<TDto> entities);
        bool Remove(string id);
        bool RemoveRange(IEnumerable<string> id);
        void Update(TDto entity);
    }
}
