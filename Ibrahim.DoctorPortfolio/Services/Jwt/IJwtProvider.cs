using Microsoft.AspNetCore.Identity;

namespace Ibrahim.DoctorPortfolio.Services.Jwt
{
    public interface IJwtProvider
    {
        string Create(IdentityUser user);
    }
}
