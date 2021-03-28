using MultiTierProject.Core.Intefaceses.Repositories;
using MultiTierProject.Core.Intefaceses.Services;
using MultiTierProject.Core.Intefaceses.UnitOfWorks;
using MultiTierProject.Core.Models;

namespace MultiTierProject.Service.Services
{
    public class TaskService : Service<Task>, ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(IUnitOfWork unitOfWork, IRepository<Task> repository, ITaskRepository taskRepository) : base(unitOfWork, repository)
        {
            _taskRepository = taskRepository;
        }
    }
}
