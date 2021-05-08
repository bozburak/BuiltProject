using Core.Utilities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Intefaceses.Services
{
    public interface IService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<Response<TDto>> GetByIdAsync(string id);
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Response<IEnumerable<TDto>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<Response<TDto>> AddAsync(TDto entity);
        Task<Response<IEnumerable<TDto>>> AddRangeAsync(IEnumerable<TDto> entities);
        Response<NoContent> Remove(string id);
        Response<NoContent> RemoveRange(IEnumerable<string> id);
        Response<NoContent> Update(TDto entity);
    }
}
