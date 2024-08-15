using Ibrahim.DoctorPortfolio.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Ibrahim.DoctorPortfolio.Extensions.DependencyInjection
{
    public static class ApiConfigurationExtensions
    {
        public static IServiceCollection ConfigureApiBehaviorOptions(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(o =>
            {
                o.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);

                    return new BadRequestObjectResult(ValidationResponse.Create(errors));
                };
            });

            return services;
        }
    }
}
