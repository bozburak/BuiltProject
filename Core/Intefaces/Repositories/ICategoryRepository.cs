using Core.AutoMapper.DTOs;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Intefaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<CategoryDto> GetCategoryWithTasksByIdAsync(int categoryId);
    }
}
