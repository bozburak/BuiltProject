using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Core.AutoMapper.DTOs;
using Microsoft.AspNetCore.Diagnostics;
using System.Collections.Generic;
using System.Text.Json;

namespace Core.Extensions
{
    public static class CustomExceptionHandler
    {
        public static void CustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var ex = context.Features.Get<IExceptionHandlerFeature>();

                    if (ex != null)
                    {
                        ErrorDto errorDto = new ErrorDto
                        {
                            Status = 500,
                            Errors = new List<string>() { ex.Error.Message }
                        };
                        await context.Response.WriteAsync(JsonSerializer.Serialize(errorDto));
                    }
                });
            });
        }
    }
}
