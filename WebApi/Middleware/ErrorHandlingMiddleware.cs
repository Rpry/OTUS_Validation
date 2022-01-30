using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebApi.Middleware
{
    /// <summary>
    /// Error handling middleware
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        /// <param name="webHostEnvironment"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger, IWebHostEnvironment webHostEnvironment)
        {
            try
            {
                context.Request.EnableBuffering();
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, logger, webHostEnvironment);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex, ILogger<ErrorHandlingMiddleware> logger, IWebHostEnvironment webHostEnvironment)
        {
            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(result);
        }
    }
}