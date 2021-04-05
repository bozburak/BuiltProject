using Core.Models;
using System.Threading.Tasks;

namespace Core.Intefaceses.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryWithTasksByIdAsync(long categoryId);
    }
}
