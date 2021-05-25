using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Core.Intefaceses.Services;
using System.Linq;
using Core.Utilities.Results;

namespace WebAPI.Filters
{
    public class NotFoundFilter<TEntity, TDto> : IActionFilter where TEntity : class where TDto : class
    {
        private readonly IService<TEntity, TDto> _service;
        public NotFoundFilter(IService<TEntity, TDto> service)
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
                var response = Response<NoContent>.Fail("was not found in the database.", 404);
                context.Result = new NotFoundObjectResult(response);
            }
            else
            {
                context.HttpContext.Items.Add("entity", entity);
            }
        }
    }
}
