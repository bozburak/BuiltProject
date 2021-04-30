﻿using Core.Aspects.AspectInjector.Caching.Triggers;
using Core.Aspects.AspectInjector.Validation.Triggers;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Intefaceses.Repositories;
using Core.Intefaceses.Services;
using Core.Intefaceses.UnitOfWorks;
using Core.Models;
using System.Collections;
using System.Collections.Generic;
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

        [CacheAttribute("GetAllAsync")]
        public new async Task<IEnumerable<Core.Models.Task>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        [ValidationAttribute(typeof(ValidationRules.FluentValidation.TaskValidator))]
        public new async Task<Core.Models.Task> AddAsync(Core.Models.Task entity)
        {
            return await base.AddAsync(entity);
        }
    }
}
