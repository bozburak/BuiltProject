using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Core.AutoMapper.DTOs;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results;

namespace WebAPI.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                IEnumerable<string> errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage);
                var response = Response<NoContent>.Fail(errors, 404);
                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
