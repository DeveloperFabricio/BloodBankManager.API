using System.Net;
using System.Text.Json;

namespace BloodBankManager.API.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly RequestDelegate _next;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new { sucess = false, message = ex.Message }));
        }
    }
}
