using System.Security.Claims;

namespace Ibrahim.DoctorPortfolio.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? Id(this ClaimsPrincipal claims)
            => claims.FindFirstValue(ClaimTypes.NameIdentifier);

        public static string? Email(this ClaimsPrincipal claims)
            => claims.FindFirstValue(ClaimTypes.Email);
    }
}
