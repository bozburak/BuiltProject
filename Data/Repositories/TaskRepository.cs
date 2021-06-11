using Core.AutoMapper;
using Core.AutoMapper.DTOs;
using Core.Intefaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TaskRepository : Repository<Core.Models.Task>, ITaskRepository
    {
        private ProjectDbContext _projectDbContext { get => _context as ProjectDbContext; }
        public TaskRepository(ProjectDbContext dbContext) : base(dbContext) { }
        public async Task<TaskDto> GetTaskWithCategoryByIdAsync(int taskId)
        {
            var result = await _projectDbContext.Tasks.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == taskId);
            return ObjectMapper.Mapper.Map<TaskDto>(result);
        }
    }
}
