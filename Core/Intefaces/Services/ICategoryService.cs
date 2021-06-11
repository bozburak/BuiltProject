using Core.AutoMapper.DTOs;
using Core.Models;
using Core.Utilities.Results;
using System.Threading.Tasks;

namespace Core.Intefaces.Services
{
    public interface ICategoryService : IService<Category, CategoryDto>
    {
        Task<Response<CategoryDto>> GetCategoryWithTasksByIdAsync(int categoryId);
    }
}
