using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.AutoMapper.DTOs;
using Core.Intefaces.Services;
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
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [ServiceFilter(typeof(NotFoundFilter<Category, CategoryDto>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Add(CategoryDto category)
        {
            var newCategory = await _categoryService.AddAsync(category);
            return Created(string.Empty, newCategory);
        }

        [HttpPut]
        public IActionResult Update(CategoryDto category)
        {
            _categoryService.Update(category);
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter<Category, CategoryDto>))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Remove(id);
            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter<Category, CategoryDto>))]
        [HttpGet("/CategoryWithTasks/{id}")]
        public IActionResult CategoryWithTasks(int id)
        {
            var category = _categoryService.GetCategoryWithTasksByIdAsync(id).Result;
            return Ok(category);
        }
    }
}
