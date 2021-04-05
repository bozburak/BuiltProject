using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.AutoMapper.DTOs;
using Core.Intefaceses.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Filters;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        public TasksController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<TaskDto>>(tasks));
        }

        [ServiceFilter(typeof(NotFoundFilter<Core.Models.Task>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            return Ok(_mapper.Map<TaskDto>(task));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(TaskDto task)
        {
            var newTask = await _taskService.AddAsync(_mapper.Map<Core.Models.Task>(task));
            return Created(string.Empty, _mapper.Map<TaskDto>(newTask));
        }

        [HttpPut]
        public IActionResult Update(TaskDto task)
        {
            var updateTask = _taskService.Update(_mapper.Map<Core.Models.Task>(task));
            return Ok(_mapper.Map<TaskDto>(task));
        }

        [ServiceFilter(typeof(NotFoundFilter<Core.Models.Task>))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = _taskService.GetByIdAsync(id).Result;
            _taskService.Remove(task);
            return Ok(_mapper.Map<TaskDto>(task));
        }
    }
}
