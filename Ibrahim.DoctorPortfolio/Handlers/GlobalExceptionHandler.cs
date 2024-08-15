using Ibrahim.DoctorPortfolio.Errors;
using Microsoft.AspNetCore.Diagnostics;

namespace Ibrahim.DoctorPortfolio.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var exceptionMessage = InnerExceptionMessage(exception);
            var exceptionDetails = exception.StackTrace?.ToString();

            _logger.LogError("Exception occurred: {Message}\n{Details}", exception.Message, exceptionDetails);

            var errorResponse = ExceptionResponse.Create();

            if (_webHostEnvironment.IsDevelopment())
                errorResponse = ExceptionResponse.Create(exceptionMessage, exceptionDetails);

            httpContext.Response.StatusCode = errorResponse.Status;
            await httpContext.Response.WriteAsJsonAsync(errorResponse);

            return true;
        }

        private string InnerExceptionMessage(Exception exception)
        {
            if(exception.InnerException != null)
                return InnerExceptionMessage(exception.InnerException);

            return exception.Message;
        }
    }
}
