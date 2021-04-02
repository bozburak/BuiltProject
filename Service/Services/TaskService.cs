using Core.Intefaceses.Repositories;
using Core.Intefaceses.Services;
using Core.Intefaceses.UnitOfWorks;
using Core.Models;

namespace Service.Services
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
