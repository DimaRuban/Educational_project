using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace StorePhoneAPI.Filters
{
    public class RequestBodyActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(context.HttpContext.Request.Body);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Executing: { context.HttpContext.Request.Body}");
        }
    }
}