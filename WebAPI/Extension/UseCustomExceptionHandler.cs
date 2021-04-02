using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Core.AutoMapper.DTOs;
using Newtonsoft.Json;

namespace WebAPI.Extension
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomExceptio(this IApplicationBuilder app)
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
                            Status = 500
                        };
                        errorDto.Errors.Add(ex.Error.Message);
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));
                    }
                });
            });
        }
    }
}
