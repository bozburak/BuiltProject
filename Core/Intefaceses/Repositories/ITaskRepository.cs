using Core.AutoMapper.DTOs;
using System.Threading.Tasks;

namespace Core.Intefaceses.Repositories
{
    public interface ITaskRepository : IRepository<Core.Models.Task> 
    {
        Task<TaskDto> GetTaskWithCategoryByIdAsync(string taskId);
    }
}
