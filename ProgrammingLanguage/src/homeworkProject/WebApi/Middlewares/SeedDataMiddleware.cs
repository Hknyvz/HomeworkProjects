using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate _next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, )
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SeedDataMiddlewareExtensions
    {
        public static IApplicationBuilder UseSeedDataMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SeedDataMiddleware>();
        }
    }
}
