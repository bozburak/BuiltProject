using Core.AutoMapper.DTOs;
using Core.Utilities.Results;
using System.Threading.Tasks;

namespace Core.Intefaces.Services
{
    public interface ITaskService : IService<Core.Models.Task, TaskDto>
    {
        Task<Response<TaskDto>> GetTaskWithCategoryByIdAsync(int taskId);
    }
}
