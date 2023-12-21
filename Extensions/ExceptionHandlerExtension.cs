using System.Net;
using api_team.Utils;
using Microsoft.AspNetCore.Diagnostics;

namespace api_team.Extensions;

public static class ExceptionHandlerExtension
{
    public static WebApplication AddExceptionAdvice(this WebApplication app)
    {
        
        app.UseExceptionHandler(opt => {
            opt.Run(async context => {
                var error = context.Features.Get<IExceptionHandlerFeature>()?.Error as APIException;

                context.Response.StatusCode = error is null ? (int) HttpStatusCode.BadRequest : error.StatusCode;

                await context.Response.WriteAsJsonAsync(new {
                    error!.Title,
                    error.StatusCode,
                    error.Message
                });
            });
        });

        return app;
    }
}