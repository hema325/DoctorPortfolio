namespace Ibrahim.DoctorPortfolio.Errors
{
    public class ExceptionResponse: ErrorResponse
    {
        public string? Details { get; }

        public ExceptionResponse(string? message = null, string? details = null) : base(500, message)
        {
            Details = details;
        }

        // factories
        public static ExceptionResponse Create(string? message = null, string? details = null) 
            => new ExceptionResponse(message, details);
    }
}
