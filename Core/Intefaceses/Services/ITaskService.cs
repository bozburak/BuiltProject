using Core.AutoMapper.DTOs;
using System.Threading.Tasks;

namespace Core.Intefaceses.Services
{
    public interface ITaskService : IService<Core.Models.Task, TaskDto>
    {
        Task<TaskDto> GetTaskWithCategoryByIdAsync(string taskId);
    }
}
