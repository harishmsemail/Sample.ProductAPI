using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Sample.ProductAPI.Middleware
{
    /// <summary>
    /// Handles exceptions globally for the application
    /// </summary>
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Tries to handle the specified exception asynchronously.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="exception">The exception to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous handling operation. Returns true if the exception was handled.</returns>
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            // Log the exception with details
            _logger.LogError(
                exception, "An unhandled exception occurred: {Message}", exception.Message);

            // Create a user-friendly problem details response
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "An internal server error occurred.",
                Detail = "An unexpected error occurred while processing your request. Please try again later.",
                Instance = httpContext.Request.Path
            };

            // Set the response status code and write the problem details to the response
            httpContext.Response.StatusCode = problemDetails.Status.Value;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            // Return true to indicate that the exception has been handled
            return true;
        }
    }
}