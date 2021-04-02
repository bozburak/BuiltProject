using Core.Intefaceses.Repositories;
using Core.Models;

namespace Data.Repositories
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        private ProjectDbContext ProjectDbContext { get => _context as ProjectDbContext; }
        public TaskRepository(ProjectDbContext dbContext) : base(dbContext) { }
    }
}
