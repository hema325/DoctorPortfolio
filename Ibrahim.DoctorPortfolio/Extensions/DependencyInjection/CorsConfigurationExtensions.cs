namespace Ibrahim.DoctorPortfolio.Extensions.DependencyInjection
{
    public static class CorsConfigurationExtensions
    {
        public static IServiceCollection AddDefaultCors(this IServiceCollection services)
        {
            services.AddCors(o =>
            {
                o.AddDefaultPolicy(p =>
                {
                    p.AllowAnyOrigin();
                    p.AllowAnyHeader();
                    p.AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
