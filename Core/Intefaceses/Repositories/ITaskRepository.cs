using System.Threading.Tasks;

namespace Core.Intefaceses.Repositories
{
    public interface ITaskRepository : IRepository<Core.Models.Task> 
    {
        Task<Core.Models.Task> GetTaskWithCategoryByIdAsync(long taskId);
    }
}
