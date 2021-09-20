using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace StorePhoneAPI.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;

        public ExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            _logger.LogError($"Action - {context.ActionDescriptor.DisplayName} have error: {context.Exception.Message}");
        }
    }
}