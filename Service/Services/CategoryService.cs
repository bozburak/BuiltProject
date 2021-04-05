using Core.Intefaceses.Repositories;
using Core.Intefaceses.Services;
using Core.Intefaceses.UnitOfWorks;
using Core.Models;

namespace Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository, ICategoryRepository categoryRepository) : base(unitOfWork, repository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
