using MultiTierProject.Core.Intefaceses.Repositories;
using MultiTierProject.Core.Models;

namespace MultiTierProject.Data.Repositories
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        private MultiTierDbContext MultiTierDbContext { get => _context as MultiTierDbContext; }
        public TaskRepository(MultiTierDbContext dbContext) : base(dbContext) { }
    }
}
