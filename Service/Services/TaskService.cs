﻿using Core.Aspects.AspectInjector.Caching.Triggers;
using Core.Aspects.AspectInjector.Validation.Triggers;
using Core.AutoMapper.DTOs;
using Core.Intefaceses.Repositories;
using Core.Intefaceses.Services;
using Core.Intefaceses.UnitOfWorks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TaskService : Service<Core.Models.Task, TaskDto>, ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(IUnitOfWork unitOfWork, IRepository<Core.Models.Task> repository, ITaskRepository taskRepository) : base(unitOfWork, repository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<TaskDto> GetTaskWithCategoryByIdAsync(string taskId)
        {
            return await _taskRepository.GetTaskWithCategoryByIdAsync(taskId);
        }

        [CacheAttribute("GetAllAsync")]
        public new async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        [ValidationAttribute(typeof(ValidationRules.FluentValidation.TaskValidator))]
        public new async Task<TaskDto> AddAsync(TaskDto entity)
        {
            return await base.AddAsync(entity);
        }
    }
}
