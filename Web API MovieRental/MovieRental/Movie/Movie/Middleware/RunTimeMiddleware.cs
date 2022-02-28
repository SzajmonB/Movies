using System.Runtime.InteropServices;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NLog;
using Microsoft.Extensions.Logging;
using Movie.Exceptions;
using System.Diagnostics;

namespace Movie.Middleware
{
    public class RunTimeMiddlewar : IMiddleware
    {
        private readonly ILogger<RunTimeMiddlewar> _logger;
        private Stopwatch _stopwatch;
        public RunTimeMiddlewar(ILogger<RunTimeMiddlewar> logger)
        {
            _logger = logger;
            _stopwatch = new Stopwatch();
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();
            await next.Invoke(context);
            _stopwatch.Stop();

            var elapsedMiliseconds = _stopwatch.ElapsedMilliseconds;
            if (elapsedMiliseconds/100>4)
            {
                var message = $"Request [{context.Request.Method} at {context.Request.Path} took {elapsedMiliseconds} ms";

                _logger.LogInformation(message);
            }
        }
    }
}