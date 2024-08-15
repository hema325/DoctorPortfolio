namespace Ibrahim.DoctorPortfolio.Settings
{
    public class JwtSettings
    {
        public const string SectionName = "JWT";

        public string Key { get; init; }
        public string Issuer { get; init; }
        public double ExpirationInDays { get; init; }
    }
}
