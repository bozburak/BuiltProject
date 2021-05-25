using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.AutoMapper.DTOs;
using Core.Intefaceses.Services;
using System.Threading.Tasks;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllAsync();
            return Ok(tasks);
        }

        [ServiceFilter(typeof(NotFoundFilter<Task, TaskDto>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            return Ok(task);
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Add(TaskDto task)
        {
            var newTask = await _taskService.AddAsync(task);
            return Created(string.Empty, newTask);
        }

        [HttpPut]
        public IActionResult Update(TaskDto task)
        {
            _taskService.Update(task);
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter<Core.Models.Task, TaskDto>))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.Remove(id);
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter<Core.Models.Task, TaskDto>))]
        [HttpGet("/TaskWithCategory/{id}")]
        public IActionResult TaskWithCategory(int id)
        {
            var task = _taskService.GetTaskWithCategoryByIdAsync(id).Result;
            return Ok(task);
        }
    }
}
