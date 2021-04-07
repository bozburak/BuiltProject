using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.AutoMapper.DTOs;
using Core.Intefaceses.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Filters;
using Core.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto category)
        {
            var newCategory = await _categoryService.AddAsync(_mapper.Map<Category>(category));
            return Created(string.Empty, _mapper.Map<CategoryDto>(newCategory));
        }

        [HttpPut]
        public IActionResult Update(CategoryDto category)
        {
            var updateTask = _categoryService.Update(_mapper.Map<Category>(category));
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var category = _categoryService.GetByIdAsync(id).Result;
            _categoryService.Remove(category);
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpGet("/CategoryWithTasks/{id}")]
        public IActionResult CategoryWithTasks(long id)
        {
            var category = _categoryService.GetCategoryWithTasksByIdAsync(id).Result;
            return Ok(_mapper.Map<CategoryDto>(category));
        }
    }
}
