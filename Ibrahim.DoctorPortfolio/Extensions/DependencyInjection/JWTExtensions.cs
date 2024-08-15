using Ibrahim.DoctorPortfolio.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Ibrahim.DoctorPortfolio.Extensions.DependencyInjection
{
    public static class JWTExtensions
    {
        public static IServiceCollection AddJWT(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                var settings = config.GetSection(JwtSettings.SectionName)
                .Get<JwtSettings>()!;

                o.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = settings.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key))
                };
            });

            return services;
        }
    }
}
