using Core.AutoMapper.DTOs;
using System.Threading.Tasks;

namespace Core.Intefaces.Repositories
{
    public interface ITaskRepository : IRepository<Core.Models.Task> 
    {
        Task<TaskDto> GetTaskWithCategoryByIdAsync(int taskId);
    }
}
