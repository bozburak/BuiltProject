using Core.Intefaceses.Repositories;
using Core.Intefaceses.Services;
using Core.Intefaceses.UnitOfWorks;
using Core.Models;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TaskService : Service<Core.Models.Task>, ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(IUnitOfWork unitOfWork, IRepository<Core.Models.Task> repository, ITaskRepository taskRepository) : base(unitOfWork, repository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<Core.Models.Task> GetTaskWithCategoryByIdAsync(long taskId)
        {
            return await _taskRepository.GetTaskWithCategoryByIdAsync(taskId);
        }
    }
}
