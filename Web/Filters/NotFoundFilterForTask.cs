using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Core.AutoMapper.DTOs;
using Core.Intefaceses.Services;
using System.Linq;
using Core.Utilities.DTOs;

namespace Web.Filters
{
    public class NotFoundFilterForTask : IActionFilter
    {
        private readonly ITaskService _service;
        public NotFoundFilterForTask(ITaskService service)
        {
            _service = service;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var id = (string)context.ActionArguments.Values.FirstOrDefault();
            var entity = _service.GetByIdAsync(id).Result;
            if (entity == null)
            {
                var response = Response<NoData>.Fail("was not found in the database.", 404);
                context.Result = new JsonResult(response);
            }
            else
            {
                context.HttpContext.Items.Add("entity", entity);
            }
        }
    }
}
