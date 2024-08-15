
namespace Ibrahim.DoctorPortfolio.Errors
{
    public class ErrorResponse
    {
        public int Status { get; }
        public string? Message { get; }

        public ErrorResponse(int status, string? message = null)
        {
            Status = status;
            Message = message ?? DefaultMessage(status);
        }

        private string? DefaultMessage(int status) => status switch
        {
            400 => "Validation failed. Please check your input data.",
            401 => "You are unauthorized to access this resource.",
            403 => "You don't have permission to access this resource.",
            404 => "The requested resource was not found.",
            409 => "Unable to complete the requested operation due to a conflict.",
            500 => "Server encountered an unexpected error. Please retry later or contact support for assistance.",
            _ => null
        };

        // factories
        public static ErrorResponse Create(int status, string? message = null)
            => new ErrorResponse(status, message);
        
        public static ErrorResponse NotFound(string? message = null)
         => new ErrorResponse(404, message);

        public static ErrorResponse Conflict(string? message = null)
         => new ErrorResponse(409, message);

        public static ErrorResponse Unauthorized(string? message = null)
         => new ErrorResponse(401, message);

        public static ErrorResponse Forbidden(string? message = null)
         => new ErrorResponse(403, message);

        public static ErrorResponse BadRequest(string? message = null)
         => new ErrorResponse(400, message);
    }
}
