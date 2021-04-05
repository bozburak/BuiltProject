using Core.Intefaceses.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ProjectDbContext _projectDbContext { get => _context as ProjectDbContext; }
        public CategoryRepository(ProjectDbContext dbContext) : base(dbContext) { }

        public async Task<Category> GetCategoryWithTasksByIdAsync(long categoryId)
        {
            return await _projectDbContext.Categories.Include(x => x.Tasks).SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
