using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Infrastructure.Middleware
{
    public class ErrorHandlingMidleware
    {
        RequestDelegate _Next;
        ILogger<ErrorHandlingMidleware> _Logger;
        public ErrorHandlingMidleware (RequestDelegate Next, ILogger<ErrorHandlingMidleware> Logger)
        {
            _Next = Next;
            _Logger = Logger;
        }
        public async Task Invoke (HttpContext context)
        {
            try
            {
                await _Next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                throw;
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _Logger.LogError(exception, "ErorLog", context);
            return Task.CompletedTask;
        }
    }
}
