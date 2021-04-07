using Core.Models;
using System.Threading.Tasks;

namespace Core.Intefaceses.Services
{
    public interface ITaskService : IService<Core.Models.Task>
    {
        Task<Core.Models.Task> GetTaskWithCategoryByIdAsync(long taskId);
    }
}
