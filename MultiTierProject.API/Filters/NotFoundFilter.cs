using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MultiTierProject.API.AutoMapper.DTOs;
using MultiTierProject.Core.Intefaceses.Services;

namespace MultiTierProject.API.Filters
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
            object tmpId;
            int id = 0;
            if (context.ActionArguments.TryGetValue("Id", out tmpId) && int.TryParse(tmpId.ToString(), out id))
            {
                if (id == 0)
                {
                    ErrorDto errorDto = new ErrorDto { Status = 400 };
                    errorDto.Errors.Add(" Bu servisde \"Id\" parametresi ile sorgu yapılır.");
                    context.Result = new BadRequestObjectResult(errorDto);
                    return;
                }
            }
            var entity = _service.GetByIdAsync(id).Result;
            if (entity == null)
            {
                ErrorDto errorDto = new ErrorDto { Status = 404 };
                errorDto.Errors.Add($"id'si {id} olan veri bulunmamaktadır.");
                context.Result = new NotFoundObjectResult(errorDto);
            }
            else
            {
                context.HttpContext.Items.Add("entity", entity);
            }
        }
    }
}
