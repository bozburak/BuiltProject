using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Core.AutoMapper.DTOs;
using Core.Intefaceses.Services;
using Web.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ILogger<TasksController> _logger;
        //private readonly TaskClientService<TaskDto> _apiClient;
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TasksController(ITaskService taskService, ILogger<TasksController> logger, IMapper mapper)
        {
            _taskService = taskService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetAllAsync();
            //var result = await _apiClient.GetAllAsync();
            _logger.LogInformation("GetAll");
            var x = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return View(_mapper.Map<IEnumerable<TaskDto>>(tasks));
        }

        [HttpPost]
        public async Task<JsonResult> Create(TaskDto taskDto)
        {
            var newTask = await _taskService.AddAsync(_mapper.Map<Core.Models.Task>(taskDto));
            //var result = await _apiClient.AddAsync(taskDto);
            var resultJson = JsonConvert.SerializeObject(_mapper.Map<TaskDto>(newTask));
            _logger.LogInformation($"Added Task: {resultJson}");
            return Json(resultJson);
        }

        [HttpPut]
        public JsonResult Update(TaskDto taskDto)
        {
            //var updateTask = _apiClient.Update(_mapper.Map<Task>(taskDto));
            var result = _taskService.Update(_mapper.Map<Core.Models.Task>(taskDto));
            _logger.LogInformation($"Updated Task Name: {result?.Name}");
            return Json(_mapper.Map<TaskDto>(result));
        }

        [ServiceFilter(typeof(NotFoundFilterForTask))]
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            //var result = _apiClient.Remove(id);
            var task = _taskService.GetByIdAsync(id).Result;
            var result = _taskService.Remove(task);
            _logger.LogInformation($"is it removed task?: {result}");
            return Json(result);
        }
    }
}
