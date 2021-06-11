using Core.AutoMapper;
using Core.AutoMapper.DTOs;
using Core.Intefaces.Repositories;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ProjectDbContext _projectDbContext { get => _context as ProjectDbContext; }
        public CategoryRepository(ProjectDbContext dbContext) : base(dbContext) { }

        public async Task<CategoryDto> GetCategoryWithTasksByIdAsync(int categoryId)
        {
            var result = await _projectDbContext.Categories.Include(x => x.Tasks).SingleOrDefaultAsync(x => x.Id == categoryId);
            return ObjectMapper.Mapper.Map<CategoryDto>(result);
        }
    }
}
