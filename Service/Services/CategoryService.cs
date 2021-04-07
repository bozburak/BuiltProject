using Core.Intefaceses.Repositories;
using Core.Intefaceses.Services;
using Core.Intefaceses.UnitOfWorks;
using Core.Models;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository, ICategoryRepository categoryRepository) : base(unitOfWork, repository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> GetCategoryWithTasksByIdAsync(long categoryId)
        {
            return await _categoryRepository.GetCategoryWithTasksByIdAsync(categoryId);
        }
    }
}
