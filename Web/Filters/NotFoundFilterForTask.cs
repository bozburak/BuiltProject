using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Core.Intefaceses.Services;
using System.Linq;
using Core.Utilities.Results;

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
            var id = (int)context.ActionArguments.Values.FirstOrDefault();
            var entity = _service.GetByIdAsync(id).Result;
            if (entity == null)
            {
                var response = Response<NoContent>.Fail("was not found in the database.", 404);
                context.Result = new JsonResult(response);
            }
            else
            {
                context.HttpContext.Items.Add("entity", entity);
            }
        }
    }
}
