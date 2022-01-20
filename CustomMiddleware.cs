using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp1
{
    public class CustomMiddleware
    {
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        await Task.Run(
            async () => 
            {
                await httpContext.Response.WriteAsync("Scheme: " + httpContext.Request.Scheme + "\n");
                await httpContext.Response.WriteAsync("Host: " + httpContext.Request.Host + "\n");
                await httpContext.Response.WriteAsync("Path: " + httpContext.Request.Path + "\n");
                await httpContext.Response.WriteAsync("QueryString: " + httpContext.Request.QueryString + "\n");
                await httpContext.Response.WriteAsync("Request Body: " + httpContext.Request.Body);
            }
        );
        //await httpContext.Response.WriteAsync("hello 123");
        //return _next(httpContext);
    }
}
}