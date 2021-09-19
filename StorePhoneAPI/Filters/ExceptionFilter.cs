using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace StorePhoneAPI.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionFilter(ILogger logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }
        public void OnException(ExceptionContext context)
        {
            if (_env.IsProduction())
            {
                context.ExceptionHandled = true;
                _logger.LogInformation($"Occurred an error - {context.Exception.Message}");
            }
            if (_env.IsEnvironment("QA"))
            {
                context.ExceptionHandled = true;
                _logger.LogInformation($"Occurred an error - {context.Exception.Message} with call stack {context.Exception.StackTrace}");
            }                   
        }
    }
}