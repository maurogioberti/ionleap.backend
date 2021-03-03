using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Neoris.Ionleap.CrossCutting.Utils.Serialization;
using Neoris.Ionleap.ResourceAccess.Responses.Infrastructure;
using System.IO;

namespace Neoris.Ionleap.RESTful.Infrastructure.Middleware
{
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorWrappingMiddleware> _logger;

        public ErrorWrappingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 500;
            }

            if (context.Response.StatusCode != 200 || !context.Response.HasStarted)
            {
                string message = "";

                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "application/json";
                    message = "Context Response has not started.";
                }

                if(string.IsNullOrEmpty(message))
                    message = "Error Status " + context.Response.StatusCode;

                var response = new BaseResponse<object>(false, message);

                string json = JsonSerializer<BaseResponse<object>>.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
