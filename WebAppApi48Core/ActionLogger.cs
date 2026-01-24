using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace WebAppApi48Core
{
    // From Claude.AI
    public class LoggingActionFilter : IAsyncActionFilter
    {
        private readonly ILogger<LoggingActionFilter> _logger;

        public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync( ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Before
            _logger.LogInformation(
                "Executing action {ActionName} on controller {ControllerName}",
                context.ActionDescriptor.DisplayName,
                context.Controller.GetType().Name);

            // Log parameters
            foreach (var arg in context.ActionArguments)
            {
                _logger.LogInformation("Parameter: {Key} = {Value}", arg.Key, arg.Value);
            }
            context.HttpContext.Request.Body.Position = 0;
            // Enable buffering
            context.HttpContext.Request.EnableBuffering();

            // Copy to memory stream
            using var memoryStream = new MemoryStream();
            await context.HttpContext.Request.Body.CopyToAsync(memoryStream);

            // Get body as string
            var body = Encoding.UTF8.GetString(memoryStream.ToArray());

            // Reset position
            context.HttpContext.Request.Body.Position = 0;

            _logger.LogInformation("Request Body: {Body}", body);

            await next(); // Executes action
                            // After
            _logger.LogInformation("Executed action {ActionName}", context.ActionDescriptor.DisplayName);
        }
    }
}
