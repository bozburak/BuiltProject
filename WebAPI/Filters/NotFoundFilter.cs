using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Core.AutoMapper.DTOs;
using Core.Intefaceses.Services;
using System.Linq;

namespace WebAPI.Filters
{
    public class NotFoundFilter<TEntity> : IActionFilter where TEntity : class
    {
        private readonly IService<TEntity> _service;
        public NotFoundFilter(IService<TEntity> service)
        {
            _service = service;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var id = (int)context.ActionArguments.Values.FirstOrDefault();
            var entity = _service.GetByIdAsync(id).Result;
            if (entity == null)
            {
                ErrorDto errorDto = new ErrorDto { Status = 404 };
                errorDto.Errors.Add($"was not found in the database.");
                context.Result = new NotFoundObjectResult(errorDto);
            }
            else
            {
                context.HttpContext.Items.Add("entity", entity);
            }
        }
    }
}
