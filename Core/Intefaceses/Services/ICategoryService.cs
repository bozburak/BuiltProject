using Core.Models;
using System.Threading.Tasks;

namespace Core.Intefaceses.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetCategoryWithTasksByIdAsync(long categoryId);
    }
}
