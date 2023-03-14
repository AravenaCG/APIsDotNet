using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs_.NET.Middleware
{
    public class TimeMiddleware
    {
        readonly RequestDelegate next;


        public TimeMiddleware(RequestDelegate nextRequest){
            next= nextRequest;
        }

        public async Task invoke(Microsoft.AspNetCore.Http.HttpContext context){
            await next(context);

            if(context.Request.Query.Any(p=> p.Key == "time")){
                await context.Response.WriteAsJsonAsync(DateTime.Now.ToShortTimeString());
            }
        }

        
    }
    public static class TimeMiddlewareExtension{
        public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }
    
}
