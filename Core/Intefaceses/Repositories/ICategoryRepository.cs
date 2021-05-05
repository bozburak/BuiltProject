using Core.AutoMapper.DTOs;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Intefaceses.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<CategoryDto> GetCategoryWithTasksByIdAsync(string categoryId);
    }
}
