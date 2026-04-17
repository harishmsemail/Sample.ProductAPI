using System.Diagnostics;

namespace Sample.ProductAPI.Middleware
{
    /// <summary>
    /// Middleware to add the default TraceId to the response headers.
    /// </summary>
    public class TraceIdMiddleware
    {
        private readonly RequestDelegate _next;

        public TraceIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Add the TraceId to the response header.           
            context.Response.Headers.Append("X-Trace-Id", Activity.Current?.Id ?? context.TraceIdentifier);

            await _next(context);
        }
    }
}