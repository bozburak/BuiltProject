using Core.AutoMapper.DTOs;
using Core.Utilities.Results;
using System.Threading.Tasks;

namespace Core.Intefaceses.Services
{
    public interface ITaskService : IService<Core.Models.Task, TaskDto>
    {
        Task<Response<TaskDto>> GetTaskWithCategoryByIdAsync(long taskId);
    }
}
