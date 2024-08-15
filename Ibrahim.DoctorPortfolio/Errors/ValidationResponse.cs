namespace Ibrahim.DoctorPortfolio.Errors
{
    public class ValidationResponse: ErrorResponse
    {
        public IEnumerable<string> Errors { get; }

        public ValidationResponse(string? message = null, IEnumerable<string> errors = null) : base(400, message)
        {
            Errors = errors;
        }

        // factories
        public static ValidationResponse Create(string? message, IEnumerable<string> errors) 
            => new ValidationResponse(message, errors);

        public static ValidationResponse Create(IEnumerable<string> errors)
            => new ValidationResponse(errors: errors);
    }
}
