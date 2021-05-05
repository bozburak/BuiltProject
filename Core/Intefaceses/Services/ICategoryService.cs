using Core.AutoMapper.DTOs;
using Core.Models;
using System.Threading.Tasks;

namespace Core.Intefaceses.Services
{
    public interface ICategoryService : IService<Category, CategoryDto>
    {
        Task<CategoryDto> GetCategoryWithTasksByIdAsync(string categoryId);
    }
}
